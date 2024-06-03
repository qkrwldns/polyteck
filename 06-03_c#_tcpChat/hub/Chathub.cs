using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatLib.Models
{
    public class Chathub
    {
        // 역직렬화 작업은 아래와 같음
        public static Chathub? Parse(string json) => JsonSerializer.Deserialize<Chathub>(json);

        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public int RoomId { get; set; }
        public string Message { get; set; } = string.Empty;

        // 직렬화 작업은 아래와 같음 
        public string ToJsonString() => JsonSerializer.Serialize(this);
    }
}
