﻿namespace API.Resources
{
    public class ProjectResource
    {

        public int UserId { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Uri { get; set; }
        
        public string[] Contributors { get; set; }
    }
}