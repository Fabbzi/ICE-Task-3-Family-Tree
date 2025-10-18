using System;
using System.Collections.Generic;

namespace RoyalFamilyTree
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAlive { get; set; }
        public FamilyMember? Spouse { get; set; }
        public List<FamilyMember> Children { get; set; }

        public FamilyMember(string name, DateTime dateOfBirth, bool isAlive)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            IsAlive = isAlive;
            Children = new List<FamilyMember>();
        }

        public int GetAge()
        {
            var endDate = IsAlive ? DateTime.Now : DateOfBirth.AddYears(100); // Approximation for deceased
            var age = endDate.Year - DateOfBirth.Year;
            if (endDate.DayOfYear < DateOfBirth.DayOfYear)
                age--;
            return age;
        }

        public string GetStatusText()
        {
            return IsAlive ? $"(Age: {GetAge()})" : "(Deceased)";
        }
    }
}
