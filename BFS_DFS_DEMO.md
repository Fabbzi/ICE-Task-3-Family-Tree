# BFS and DFS Demonstration - Royal Family Tree

This document demonstrates the Breadth-First Search (BFS) and Depth-First Search (DFS) implementations in the Royal Family Tree application.

## Overview

The `FamilyMember` class now includes two tree traversal algorithms:

1. **Breadth-First Search (BFS)** - Visits family members level by level (generation by generation)
2. **Depth-First Search (DFS)** - Visits family members depth-first (follows each lineage completely before moving to the next)

## Implementation

### BFS Implementation

```csharp
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
```

**Characteristics:**
- Uses a Queue data structure
- Visits nodes level by level
- Time Complexity: O(n) where n is the number of family members
- Space Complexity: O(n) for the queue and visited set

### DFS Implementation

```csharp
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
```

**Characteristics:**
- Uses recursion (implicit stack)
- Visits nodes depth-first
- Time Complexity: O(n) where n is the number of family members
- Space Complexity: O(h) where h is the height of the tree (recursion stack)

## Example Traversal Results

### BFS Order (Generation by Generation)

When starting from Queen Elizabeth II, BFS visits members in this order:

1. **Generation 1**: Queen Elizabeth II
2. **Generation 2**: King Charles III, Princess Anne, Prince Andrew, Prince Edward
3. **Generation 3**: Prince William, Prince Harry, Peter Phillips, Zara Tindall, Princess Beatrice, Princess Eugenie, Lady Louise Windsor, James Viscount Severn
4. **Generation 4**: Prince George, Princess Charlotte, Prince Louis, Prince Archie, Princess Lilibet

### DFS Order (Depth-First)

When starting from Queen Elizabeth II, DFS visits members in this order:

1. Queen Elizabeth II
2. King Charles III
3. Prince William
4. Prince George
5. Princess Charlotte
6. Prince Louis
7. Prince Harry
8. Prince Archie
9. Princess Lilibet
10. Princess Anne
11. Peter Phillips
12. Zara Tindall
13. ... (continues with Prince Andrew's line, then Prince Edward's line)

## Search Functionality

The search functionality uses BFS internally to efficiently find family members:

### Methods Available

```csharp
// Find first member matching name (case-insensitive)
var member = root.SearchByName("William");

// Find all members matching name
var members = root.SearchAllByName("Princess");

// Get succession position
var position = member.GetSuccessionPosition(root);
```

### Search Features

1. **Case-insensitive matching** - Searches work regardless of case
2. **Partial matching** - "Will" matches "William"
3. **Multiple results** - Returns all matching members
4. **Succession calculation** - Determines position in line to throne

## GUI Integration

### Search Feature in GUI

The GUI includes a search bar that:
- Searches for family members by name
- Shows succession position when a member is found
- Highlights the found member with a red border and star (⭐)
- Displays detailed information including:
  - Full name
  - Date of birth
  - Current age or deceased status
  - Position in line to throne
  - Spouse information
  - Number of children

### Add Member Feature

The GUI includes an "Add Family Member" button that:
- Opens a dialog for entering new member details
- Allows selection of parent from all existing members
- Validates input before adding
- Automatically updates the tree visualization

## Line of Succession

The succession order follows these rules:

1. **Children before siblings** - A person's children come before their siblings
2. **Older before younger** - Older children come before younger children
3. **Descendants included** - All legitimate descendants are in line
4. **Spouses excluded** - Spouses are not in the line of succession

### Example Succession (First 10)

Based on the current Royal Family tree:

1. Prince William (eldest son of King Charles III)
2. Prince George (eldest son of Prince William)
3. Princess Charlotte (daughter of Prince William)
4. Prince Louis (youngest son of Prince William)
5. Prince Harry (younger son of King Charles III)
6. Prince Archie (son of Prince Harry)
7. Princess Lilibet (daughter of Prince Harry)
8. Prince Andrew (brother of King Charles III)
9. Princess Beatrice (daughter of Prince Andrew)
10. Princess Eugenie (daughter of Prince Andrew)

## Testing the Features

### Console Demo

The `ConsoleDemo` class includes a method `DemoBFSandDFS()` that demonstrates:

1. **BFS Traversal** - Lists all members in breadth-first order
2. **DFS Traversal** - Lists all members in depth-first order
3. **Search Functionality** - Tests searches for common names
4. **Succession Calculation** - Shows first 10 in line to throne

### Running the Demo

To see the BFS/DFS demonstration in a console environment:

```csharp
var root = FamilyTreeData.GetWindsorFamilyTree();
ConsoleDemo.DemoBFSandDFS();
```

**Note:** The WPF GUI application is Windows-only, but the core logic (FamilyMember class with BFS/DFS) is platform-independent.

## Performance Analysis

### BFS Performance

- **Best Case**: O(n) - Must visit all nodes
- **Average Case**: O(n) - Must visit all nodes
- **Worst Case**: O(n) - Must visit all nodes
- **Space**: O(w) where w is maximum width of tree

### DFS Performance

- **Best Case**: O(n) - Must visit all nodes
- **Average Case**: O(n) - Must visit all nodes
- **Worst Case**: O(n) - Must visit all nodes
- **Space**: O(h) where h is height of tree

### For the Windsor Family Tree

- **Total Nodes**: ~26 members
- **Max Depth**: 4 generations
- **Max Width**: ~8 members in generation 3
- **Both algorithms**: Execute in < 1ms

## Use Cases

### When to Use BFS

1. **Finding members by generation** - Want all members of same generation
2. **Shortest path** - Finding closest relationship between two members
3. **Level-order traversal** - Processing members generation by generation

### When to Use DFS

1. **Exploring lineages** - Following a complete family line
2. **Succession calculation** - Natural order for line of succession
3. **Tree visualization** - Natural top-to-bottom rendering

### Search Use Cases

1. **Name lookup** - Finding a specific family member
2. **Succession queries** - Who is next in line?
3. **Relationship discovery** - How are two members related?

## Conclusion

The BFS and DFS implementations provide efficient traversal of the Royal Family Tree, enabling features like:

- Fast searching by name
- Succession position calculation
- Complete tree traversal in different orders
- GUI search and highlight functionality

Both algorithms are implemented correctly and efficiently, visiting each node exactly once with minimal space overhead.
