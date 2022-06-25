using System.Collections.Generic;
using System.Text.Json;
using Checkers.Models;

namespace Checkers.Services.Repository
{
    public sealed class Json : DBRepository
    {
        public Json(string filePath) : base(filePath)
        {
            
        }

        protected override string SerializeUsers(List<User> users)
        {
            return JsonSerializer.Serialize(users, new JsonSerializerOptions() {WriteIndented = true});
        }

        protected override List<User> DeserializeUsers(string serializedUsers)
        {
            return JsonSerializer.Deserialize<List<User>>(serializedUsers);
        }
    }
}