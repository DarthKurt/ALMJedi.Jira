using System;
using Microsoft.Azure.WebJobs.Description;

namespace Jira.Infrastructure.Functions
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class InjectAttribute : Attribute
    {
        public string Name { get; set; }
        public bool HasName => !string.IsNullOrWhiteSpace(Name);

        public InjectAttribute()
        {}

        public InjectAttribute(string name)
        {
            Name = name;
        }
    }
}