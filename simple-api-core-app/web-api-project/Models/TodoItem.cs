using System;

namespace web_api_project.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string SecretField { get; set; }
    }
}