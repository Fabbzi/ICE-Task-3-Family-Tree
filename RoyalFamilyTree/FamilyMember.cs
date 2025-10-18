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

        /// <summary>
        /// Performs Breadth-First Search (BFS) traversal of the family tree.
        /// Returns all family members in level-order (generation by generation).
        /// </summary>
        public List<FamilyMember> BreadthFirstSearch()
        {
            var result = new List<FamilyMember>();
            var queue = new Queue<FamilyMember>();
            var visited = new HashSet<FamilyMember>();

            queue.Enqueue(this);
            visited.Add(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                // Add spouse if not visited
                if (current.Spouse != null && !visited.Contains(current.Spouse))
                {
                    visited.Add(current.Spouse);
                }

                // Add children
                foreach (var child in current.Children)
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Performs Depth-First Search (DFS) traversal of the family tree.
        /// Returns all family members in depth-first order.
        /// </summary>
        public List<FamilyMember> DepthFirstSearch()
        {
            var result = new List<FamilyMember>();
            var visited = new HashSet<FamilyMember>();
            DepthFirstSearchHelper(this, result, visited);
            return result;
        }

        private void DepthFirstSearchHelper(FamilyMember member, List<FamilyMember> result, HashSet<FamilyMember> visited)
        {
            if (visited.Contains(member))
                return;

            visited.Add(member);
            result.Add(member);

            // Mark spouse as visited but don't traverse from them
            if (member.Spouse != null && !visited.Contains(member.Spouse))
            {
                visited.Add(member.Spouse);
            }

            // Recursively visit children
            foreach (var child in member.Children)
            {
                DepthFirstSearchHelper(child, result, visited);
            }
        }

        /// <summary>
        /// Searches for a family member by name (case-insensitive partial match).
        /// Returns the member if found, otherwise null.
        /// </summary>
        public FamilyMember? SearchByName(string name)
        {
            var allMembers = BreadthFirstSearch();
            return allMembers.Find(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets all family members that match the search term (case-insensitive partial match).
        /// </summary>
        public List<FamilyMember> SearchAllByName(string name)
        {
            var allMembers = BreadthFirstSearch();
            return allMembers.FindAll(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Calculates the position in line to the throne for this family member.
        /// Returns -1 if the member is not in the line of succession.
        /// </summary>
        public int GetSuccessionPosition(FamilyMember root)
        {
            var succession = GetLineOfSuccession(root);
            return succession.IndexOf(this) + 1; // +1 because position starts at 1
        }

        /// <summary>
        /// Gets the line of succession from the root (monarch).
        /// Children come before siblings, and older children come before younger children.
        /// </summary>
        private List<FamilyMember> GetLineOfSuccession(FamilyMember root)
        {
            var succession = new List<FamilyMember>();
            AddToSuccession(root, succession, new HashSet<FamilyMember>());
            return succession;
        }

        private void AddToSuccession(FamilyMember member, List<FamilyMember> succession, HashSet<FamilyMember> visited)
        {
            if (visited.Contains(member))
                return;

            visited.Add(member);

            // Skip spouses - they're not in line of succession
            if (member != this && member.Spouse != null)
            {
                visited.Add(member.Spouse);
            }

            // Don't add the root (current monarch) to succession list
            if (member != this)
            {
                succession.Add(member);
            }

            // Add children in order (older to younger)
            foreach (var child in member.Children)
            {
                AddToSuccession(child, succession, visited);
            }
        }
    }
}
