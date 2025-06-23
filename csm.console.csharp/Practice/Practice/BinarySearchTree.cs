using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice.Practice
{
    public class Program123

    {
        public static void Solution()
        {
            BinarySearchTree tree = new();
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            List<int> list = new List<int>();
            tree.LevelOrderSearch(list);

            foreach (int elem in list)
            {
                Console.WriteLine(elem);
            }


        }

        class BinarySearchTreeNode
        {
            //데이터 

            public int Data { get; set; }

            //널러블 사용한 이유 ?  >> 자식이 없을 수도 있기 때문에.
            public BinarySearchTreeNode? Left { get; set; }
            public BinarySearchTreeNode? Right { get; set; }
            public BinarySearchTreeNode? Parent { get; set; }

            public BinarySearchTreeNode(int data,  BinarySearchTreeNode? parent, BinarySearchTreeNode? left = null, BinarySearchTreeNode? right = null)
            {
                Data = data;
                Left = left;
                Right = right;
                Parent = parent;
            }

            public bool Contains(int data)
            {
                if (Data == data)
                {
                    return true;
                }
                else if (data < Data)
                {
                    if(Left == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Left.Contains(data);
                    }
                }
                // Left?.Contains(data) ?? false;
                else
                {
                    if (Right == null)
                    {
                        return false;
                    }
                    else
                    {
                        return Right.Contains(data);
                    }
                }

            }

            // 반환 값 : 새로운 루트 노드
            public BinarySearchTreeNode? Remove(int data)
            {
                // 왼쪽 자식 노드를 업데이트
                if (data < Data)
                {
                    if (Left is not null)
                    {
                        Left = Left.Remove(data);
                        if (Left is not null)
                        {
                            Left.Parent = this;
                        }
                    }

                    return this;
                }

                // 오른쪽 자식 노드를 업데이트
                if (data > Data)
                {
                    if (Right is not null)
                    {
                        Right = Right.Remove(data);
                        if (Right is not null)
                        {
                            Right.Parent = this;
                        }
                    }

                    return this;
                }

                // data == Data

                // 1. 자식 노드가 없거나 1개인 경우
                if (Left is null)
                {
                    if (Right is not null)
                    {
                        Right.Parent = Parent;
                    }

                    return Right;
                }
                else if (Right is null)
                {
                    if (Left is not null)
                    {
                        Left.Parent = Parent;
                    }

                    return Left;
                }

                // 자식 노드가 2개인 경우
                // 후속자 노드를 찾는다.
                // 오른쪽 서브트리에서 가장 최솟값
                BinarySearchTreeNode successor = FindMin();

                // 후속자 노드의 데이터 복사
                Data = successor.Data;

                // 오른쪽 서브트리에서 후속자 노드를 삭제한다.
                Right = Right.Remove(Data);
                if (Right is not null)
                {
                    Right.Parent = this;
                }

                return this;
            }


            public BinarySearchTreeNode FindMin()
            {

                BinarySearchTreeNode current = this;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current;
            }


            public bool Insert(int data)
            {
                // 뭘 함?
                //만약에 >> 나보다 작으면? >> LEFT
                //만약에 >> 나보다 크면? >> RIGHT
                //만약에 >> 나랑 같으면?  >> 
                if (Data == data)
                {
                    return false;
                }
                //나보다 작으면 왼쪽
                else if (data < Data)
                {
                    if(Left == null)
                    {
                        Left = new BinarySearchTreeNode(data, this);
                    }
                    else
                    {
                        Left.Insert(data);
                    }
                    return true;
                }
                else
                {
                    if(Right == null)
                    {
                        Right = new BinarySearchTreeNode(data, this);
                    }
                    else
                    {
                        Right.Insert(data);
                    }
                    return true;
                }
               
            }

            public void InOrderSearch(List<int> list)
            {
                Left?.InOrderSearch(list);
                list.Add(Data);
                Right?.InOrderSearch(list);
            }

            public void PreOrderSearch(List<int> list)
            {
                list.Add(Data);
                Left?.PreOrderSearch(list);
                Right?.PreOrderSearch(list);
            }

            public void ReOrderSearch(List<int> list)
            {
                Left?.ReOrderSearch(list);
                Right?.ReOrderSearch(list);
                list.Add(Data);
            }

        }



        class BinarySearchTree
        {
            private BinarySearchTreeNode? _root;

            public bool Contains(int data)
            {
                if(_root is null)
                {
                    return false;
                }
                return _root.Contains(data);
            }

            public void Insert(int data)
            {
                if (_root == null)
                {
                    _root = new BinarySearchTreeNode(data, null);
                }
                _root?.Insert(data);


            }

            public void InOrderSearch(List<int> list)
            {
                _root?.InOrderSearch(list);
            }

            public void PreOrderSearch(List<int> list)
            {
                _root?.InOrderSearch(list);
            }


            public void ReOrderSearch(List<int> list)
            {
                _root?.InOrderSearch(list);
            }

            public void LevelOrderSearch(List<int> list)
            {
                if(_root is null)
                {
                    return;
                }

                Queue<BinarySearchTreeNode> queue = new Queue<BinarySearchTreeNode>();

                queue.Enqueue(_root);

                while (queue.Count > 0)
                {
                    BinarySearchTreeNode node = queue.Dequeue();

                    list.Add(node.Data);

                    if(node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }

                }

            }

        }
    }
}
