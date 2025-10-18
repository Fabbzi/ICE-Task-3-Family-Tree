using System;
using System.Collections.Generic;

namespace RoyalFamilyTree
{
    // This class provides a console-based demo of the family tree
    // It can be used for testing without running the GUI
    public static class ConsoleDemo
    {
        public static void PrintFamilyTree(FamilyMember member, int level = 0)
        {
            string indent = new string(' ', level * 4);
            string statusSymbol = member.IsAlive ? "✓" : "✗";
            
            Console.WriteLine($"{indent}{statusSymbol} {member.Name}");
            Console.WriteLine($"{indent}   Born: {member.DateOfBirth:MMM d, yyyy} - {member.GetStatusText()}");
            
            if (member.Spouse != null)
            {
                string spouseStatus = member.Spouse.IsAlive ? "✓" : "✗";
                Console.WriteLine($"{indent}   {spouseStatus} Married to: {member.Spouse.Name}");
                Console.WriteLine($"{indent}      Born: {member.Spouse.DateOfBirth:MMM d, yyyy} - {member.Spouse.GetStatusText()}");
            }
            
            if (member.Children.Count > 0)
            {
                Console.WriteLine($"{indent}   Children:");
                foreach (var child in member.Children)
                {
                    PrintFamilyTree(child, level + 1);
                }
            }
            
            Console.WriteLine();
        }

        public static void Run()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("       THE HOUSE OF WINDSOR - FAMILY TREE");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("Legend: ✓ = Alive, ✗ = Deceased");
            Console.WriteLine();
            
            var root = FamilyTreeData.GetWindsorFamilyTree();
            PrintFamilyTree(root);
            
            Console.WriteLine("═══════════════════════════════════════════════════════");
        }

        public static void DemoBFSandDFS()
        {
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║     BFS & DFS TRAVERSAL DEMONSTRATION                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");
            
            var root = FamilyTreeData.GetWindsorFamilyTree();

            // Demonstrate BFS
            Console.WriteLine("BREADTH-FIRST SEARCH (BFS) Traversal:");
            Console.WriteLine("───────────────────────────────────────────────────────");
            Console.WriteLine("Visits family members level by level (generation by generation)");
            Console.WriteLine();
            
            var bfsResult = root.BreadthFirstSearch();
            for (int i = 0; i < bfsResult.Count; i++)
            {
                var member = bfsResult[i];
                Console.WriteLine($"{i + 1,3}. {member.Name} (Born: {member.DateOfBirth:yyyy})");
            }
            
            Console.WriteLine($"\nTotal members visited: {bfsResult.Count}");
            
            // Demonstrate DFS
            Console.WriteLine("\n\nDEPTH-FIRST SEARCH (DFS) Traversal:");
            Console.WriteLine("───────────────────────────────────────────────────────");
            Console.WriteLine("Visits family members depth-first (follows each lineage completely)");
            Console.WriteLine();
            
            var dfsResult = root.DepthFirstSearch();
            for (int i = 0; i < dfsResult.Count; i++)
            {
                var member = dfsResult[i];
                Console.WriteLine($"{i + 1,3}. {member.Name} (Born: {member.DateOfBirth:yyyy})");
            }
            
            Console.WriteLine($"\nTotal members visited: {dfsResult.Count}");
            
            // Demonstrate Search
            Console.WriteLine("\n\nSEARCH FUNCTIONALITY:");
            Console.WriteLine("───────────────────────────────────────────────────────");
            
            var searchTests = new List<string> { "William", "George", "Charles", "Elizabeth" };
            
            foreach (var searchTerm in searchTests)
            {
                Console.WriteLine($"\nSearching for '{searchTerm}':");
                var results = root.SearchAllByName(searchTerm);
                
                if (results.Count == 0)
                {
                    Console.WriteLine("  No results found.");
                }
                else
                {
                    foreach (var member in results)
                    {
                        var position = member.GetSuccessionPosition(root);
                        var positionText = position > 0 ? $"#{position} in line to throne" : "Not in direct succession";
                        Console.WriteLine($"  ✓ {member.Name} - {positionText}");
                    }
                }
            }
            
            // Demonstrate Line of Succession
            Console.WriteLine("\n\nLINE OF SUCCESSION TO THE THRONE:");
            Console.WriteLine("───────────────────────────────────────────────────────");
            Console.WriteLine("First 10 in line:");
            Console.WriteLine();
            
            var allMembers = root.BreadthFirstSearch();
            var count = 0;
            foreach (var member in allMembers)
            {
                var position = member.GetSuccessionPosition(root);
                if (position > 0 && position <= 10)
                {
                    Console.WriteLine($"{position,3}. {member.Name} (Born: {member.DateOfBirth:MMMM d, yyyy})");
                    count++;
                }
            }
            
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║     END OF BFS & DFS DEMONSTRATION                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");
        }
    }
}
