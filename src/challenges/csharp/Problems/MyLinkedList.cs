//https://leetcode.com/problems/design-linked-list

namespace LeetCode.Problems;

public sealed class MyLinkedList : ProblemBase
{
    [Theory]
    [ClassData(typeof(MyLinkedList))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Instructions<CustomLinkedList, int[]>(config => 
                config
                    .MapConstructor("MyLinkedList")
                    .MapInstruction("get", (it, data) => it.Get(data[0]))
                    .MapInstruction("addAtHead", (it, data) => it.AddAtHead(data[0]))
                    .MapInstruction("addAtTail", (it, data) => it.AddAtTail(data[0]))
                    .MapInstruction("addAtIndex", (it, data) => it.AddAtIndex(data[0], data[1]))
                    .MapInstruction("deleteAtIndex", (it, data) => it.DeleteAtIndex(data[0]))
            )
          .Add(it => it.Data<int>("""[[],[38],[66],[61],[76],[26],[37],[8],[5],[4],[45],[4],[85],[37],[5],[93],[10,23],[21],[52],[15],[47],[12],[6,24],[64],[4],[31],[6],[40],[17],[15],[19,2],[11],[86],[17],[55],[15],[14,95],[22],[66],[95],[8],[47],[23],[39],[30],[27],[0],[99],[45],[4],[9,11],[6],[81],[18,32],[20],[13],[42],[37,91],[36],[10,37],[96],[57],[20],[89],[18],[41,5],[23],[75],[7],[25,51],[48],[46],[29],[85],[82],[6],[38],[14],[1],[12],[42],[42],[83],[13],[14,20],[17,34],[36],[58],[2],[38],[33,59],[37],[15],[64],[56],[0],[40],[92],[63],[35],[62],[32]]""")
                       .Instructions("""["MyLinkedList","addAtHead","addAtTail","addAtTail","addAtTail","addAtTail","addAtTail","addAtTail","deleteAtIndex","addAtHead","addAtHead","get","addAtTail","addAtHead","get","addAtTail","addAtIndex","addAtTail","addAtHead","addAtHead","addAtHead","get","addAtIndex","addAtHead","get","addAtHead","deleteAtIndex","addAtHead","addAtTail","addAtTail","addAtIndex","addAtTail","addAtHead","get","addAtTail","deleteAtIndex","addAtIndex","deleteAtIndex","addAtHead","addAtTail","addAtHead","addAtHead","addAtTail","addAtTail","get","get","addAtHead","addAtTail","addAtTail","addAtTail","addAtIndex","get","addAtHead","addAtIndex","addAtHead","addAtTail","addAtTail","addAtIndex","deleteAtIndex","addAtIndex","addAtHead","addAtHead","deleteAtIndex","addAtTail","deleteAtIndex","addAtIndex","addAtTail","addAtHead","get","addAtIndex","addAtTail","addAtHead","addAtHead","addAtHead","addAtHead","addAtHead","addAtHead","deleteAtIndex","get","get","addAtHead","get","addAtTail","addAtTail","addAtIndex","addAtIndex","addAtHead","addAtTail","addAtTail","get","addAtIndex","addAtHead","deleteAtIndex","addAtTail","get","addAtHead","get","addAtHead","deleteAtIndex","get","addAtTail","addAtTail"]""")
                       .Output("[null, null, null, null, null, null, null, null, null, null, null, 61, null, null, 61, null, null, null, null, null, null, 85, null, null, 37, null, null, null, null, null, null, null, null, 23, null, null, null, null, null, null, null, null, null, null, -1, 95, null, null, null, null, null, 31, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 8, null, null, null, null, null, null, null, null, null, 6, 47, null, 23, null, null, null, null, null, null, null, 93, null, null, null, null, 48, null, 93, null, null, 59, null, null]"))
          .Add(it => it.Data<int>("""[[],[1],[0]]""")
                       .Instructions("""["MyLinkedList","addAtTail","get"]""")
                       .Output("[null, null, 1]"))
          .Add(it => it.Data<int>("""[[],[0,10],[0,20],[1,30],[0]]""")
                       .Instructions("""["MyLinkedList","addAtIndex","addAtIndex","addAtIndex","get"]""")
                       .Output("[null, null, null, null, 20]"))
          .Add(it => it.Data<int>("""[[],[7],[2],[1],[3,0],[2],[6],[4],[4],[4],[5,0],[6]]""")
                       .Instructions("""["MyLinkedList","addAtHead","addAtHead","addAtHead","addAtIndex","deleteAtIndex","addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]""")
                       .Output("[null, null, null, null, null, null, null, null, 4, null, null, null]"))
          .Add(it => it.Data<int>("""[[],[1],[3],[3,2]]""")
                       .Instructions("""["MyLinkedList","addAtHead","addAtTail","addAtIndex"]""")
                       .Output("[null, null, null, null]"))
          .Add(it => it.Data<int>("""[[],[2],[1],[2],[7],[3],[2],[5],[5],[5],[6],[4]]""")
                       .Instructions("""["MyLinkedList","addAtHead","deleteAtIndex","addAtHead","addAtHead","addAtHead","addAtHead","addAtHead","addAtTail","get","deleteAtIndex","deleteAtIndex"]""")
                       .Output("[null, null, null, null, null, null, null, null, null, 2, null, null]"))
          .Add(it => it.Data<int>("""[[],[1],[3],[1,2],[1],[1],[1]]""")
                       .Instructions("""["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]""")
                       .Output("[null, null, null, null, 2, null, 3]"));

    public class CustomLinkedList
    {
        private class Node
        {
            public int Value { get; init; }
            public Node Prev { get; set; } = default!;
            public Node? Next { get; set; }
        }

        private readonly Node _root = new();
        private int _length;

        public int Get(int index) 
            => GetNodeAt(index)?.Value ?? -1;

        public void AddAtHead(int val)
            => AddAtIndex(0, val);

        public void AddAtTail(int val) 
            => AddAtIndex(_length, val);

        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                var next = _root.Next;
                _root.Next = new Node
                {
                    Value = val, 
                    Next = next, 
                    Prev = _root
                };

                if (next != null)
                {
                    next.Prev = _root.Next;
                }

                _length++;
            }
            else if (index == _length)
            {
                var node = GetNodeAt(index - 1);
                if (node != null)
                {
                    node.Next = new Node
                    {
                        Value = val,
                        Prev = node
                    };
                    _length++;
                }
            }
            else if (index < _length)
            {
                var node = GetNodeAt(index);
                if (node != null)
                {
                    var prev = node.Prev;
                    prev.Next = new Node
                    {
                        Value = val,
                        Next = node,
                        Prev = prev
                    };
                    node.Prev = prev.Next;
                    _length++;
                }
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= _length)
            {
                return;
            }

            var node = GetNodeAt(index);
            if (node != null)
            {
                var prev = node.Prev;
                var next = node.Next;
                prev.Next = next;
                if (next != null)
                {
                    next.Prev = prev;
                }
                
                _length--;
            }
        }

        private Node? GetNodeAt(int index)
        {
            var node = _root.Next;
            while (node != null && index-- > 0)
            {
                node = node.Next;
            }

            return node;
        }

        public string? Print()
        {
            var node = _root.Next;
            string? result = null;
            while (node != null)
            {
                result += $"{node.Value}-";
                node = node.Next;
            }

            return result;
        }
    }

    public class CustomLinkedList1
    {
        private readonly List<int> _list = new();

        public int Get(int index)
        {
            if (index >= _list.Count)
            {
                return -1;
            }

            return _list[index];
        }

        public void AddAtHead(int val)
            => AddAtIndex(0, val);

        public void AddAtTail(int val)
            => AddAtIndex(_list.Count, val);

        public void AddAtIndex(int index, int val)
        {
            if (index <= _list.Count)
            {
                _list.Insert(index, val);
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index < _list.Count)
            {
                _list.RemoveAt(index);
            }
        }
    }
}