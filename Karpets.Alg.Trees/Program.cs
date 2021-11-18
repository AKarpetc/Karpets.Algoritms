using System;
using System.Collections.Generic;
using System.Linq;

namespace Karpets.Alg.Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Node();
            node.Init();

            Console.WriteLine("Поиск всех листов рекурсия");
            Recursion(node);

            int i = 1;
            nodesRecursion.OrderBy(x => x.Number).ToList().ForEach(x =>
            {
                Console.WriteLine(i + " - " + x);
                i++;
            });

            Console.WriteLine("Поиск всех листов перебор");
            Loop(node);

            i = 1;
            nodesLoop.OrderBy(x => x.Number).ToList().ForEach(x =>
            {
                Console.WriteLine(i + " - " + x);
                i++;
            });

            Console.WriteLine("Обход в ширину");

            var nodesByBreadth = GetAllNodesByBreadth(node);
            i = 1;
            nodesByBreadth.ToList().ForEach(x =>
            {
                Console.WriteLine(i + " - " + " - " + x + " - " + (x.IsList ? "List" : "Branch") + " - " + x.ParentNumber);
                i++;
            });

            Console.WriteLine("Обход в глубину");

            var nodesByDeep = GetAllNodesByDeep(node);
            i = 1;
            nodesByDeep.ToList().ForEach(x =>
            {
                Console.WriteLine(i + " - " + " - " + x + " - " + (x.IsList ? "List" : "Branch"));
                i++;
            });
            Console.Read();
        }

        #region FindAllList

        static List<Node> nodesLoop = new List<Node>();
        static List<Node> nodesRecursion = new List<Node>();
        public static void Recursion(Node root)
        {
            if (root.Children.Count() == 0)
            {
                nodesRecursion.Add(root);
            }


            foreach (var child in root.Children)
            {
                Recursion(child);
            }

        }

        public static void Loop(Node root)
        {
            var childrenNodes = root.Children;
            var newNodes = new List<Node>();


            while (childrenNodes.Count > 0)
            {
                foreach (var child in childrenNodes)
                {
                    if (child.Children.Count() == 0)
                    {
                        nodesLoop.Add(child);
                    }
                    else
                    {
                        newNodes.AddRange(child.Children);
                    }
                }

                childrenNodes = newNodes;
                newNodes = new List<Node>();
            }
        }
        #endregion

        public static IEnumerable<Node> GetAllNodesByBreadth(Node root)
        {
            var queue = new Queue<Node>();
            root.ParentNumber = -1;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                yield return node;

                if (node.Children.Count() == 0)
                {
                    node.IsList = true;
                }

                foreach (var child in node.Children)
                {
                    child.ParentNumber = node.Number;
                    queue.Enqueue(child);
                }
            }
        }

        public static IEnumerable<Node> GetAllNodesByDeep(Node root)
        {
            var resultCollection = new List<Node>();
            var stack = new Stack<Node>();

            stack.Push(root);

            while (stack.Count() > 0)
            {
                var node = stack.Pop();

                if (node.Children.Count() == 0)
                {
                    node.IsList = true;
                }

                resultCollection.Add(node);

                foreach (var child in node.Children)
                    stack.Push(child);
            }

            return resultCollection;
        }
    }

    public class Node
    {
        private static int i = 0;
        public void Init()
        {
            Children = new List<Node>
        {
             new Node(){ Children= new List<Node>
             {
                 new Node(),
                 new Node(),
                 new Node(),

             } },

             new Node(){ Children= new List<Node>
             {
                  new Node{
                      Children = new List<Node>()
                      {
                          new Node{
                              Children = new List<Node>()
                              {
                                  new Node()
                              }
                          },
                          new Node{
                              Children = new List<Node>()
                              {
                                  new Node{
                                      Children= new List<Node>
                                      {
                                           new Node()
                                           {
                                               Children = new List<Node>()
                                               {
                                                   new Node(),
                                                   new Node(),
                                               }
                                           },
                                           new Node(),
                                      }
                                  }
                              }
                          }
                      }
                  },
                  new Node() ,
                  new Node(),
             } },

             new Node(){ Children= new List<Node>
             {        new Node{
                      Children = new List<Node>()
                      {
                          new Node{
                              Children = new List<Node>()
                              {
                                  new Node()
                              }
                          },
                          new Node{
                              Children = new List<Node>()
                              {
                                  new Node{
                                      Children= new List<Node>
                                      {
                                           new Node()
                                           {
                                               Children = new List<Node>()
                                               {
                                                   new Node(),
                                                   new Node(),
                                               }
                                           },
                                           new Node(),
                                      }
                                  }
                              }
                          }
                      }
                  },
             } }
        };
        }
        public override string ToString()
        {
            return Number + " - " + Id.ToString();
        }
        public Guid Id { get; set; }

        public int Number { get; set; }

        public int ParentNumber { get; set; }

        public bool IsList { get; set; }

        public Node()
        {
            Children = new List<Node>();
            Id = Guid.NewGuid();
            Number = i++;
        }

        public List<Node> Children { get; set; }
    }
}
