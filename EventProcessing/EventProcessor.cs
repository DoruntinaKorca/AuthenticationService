


using AuthenticationService.DTOs;
using AuthenticationService.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace AuthenticationService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory,
            IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    AddUser(message);
                    break;
                case EventType.UserDeleted:
                    DeleteUser(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("------> Determining event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch(eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("-----> User published event detected");
                    return EventType.UserPublished;

                case "Deleted_User_Published":
                    Console.WriteLine("----->delete User published event detected");
                    return EventType.UserDeleted;
                default:
                    Console.WriteLine("----> could not determine event type");
                    return EventType.Undetermined;
            }
        }

        private void AddUser(string userPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IUsersRepo>();

                var userPublishedDto = JsonSerializer.Deserialize<UserPublishedDto>(userPublishedMessage);


                try
                {
                    var user = _mapper.Map<User>(userPublishedDto);

                    repo.CreateUser(user);
                    repo.SaveChanges();
                    Console.WriteLine("--->User added...");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"----> could not add user to db{ex.Message}");
                }
            }
        }
        private void DeleteUser(string userPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IUsersRepo>();

                var userPublishedDto = JsonSerializer.Deserialize<UserPublishedDto>(userPublishedMessage);


                try
                {
                    var user = _mapper.Map<User>(userPublishedDto);

                    repo.DeleteUser(user);
                    repo.SaveChanges();
                    Console.WriteLine("--->User deleted...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"----> could not delete user from db{ex.Message}");
                }
            }
        }
    }
    enum EventType
    {
        UserPublished,
        UserDeleted,
        Undetermined
    }
}
