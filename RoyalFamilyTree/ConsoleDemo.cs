using System;

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
    }
}
