using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    class node
    {
        /*Node class represents the node of doubly linked list.
         *It consists of the information part and links to
         *Its succeeding and preceeding nodes
         In terms of nest and previous nodes.*/
        public int dose;
        public string name;
        public string id;
        public string harga;
        public node next;/*points to the succeeding node*/
        public node prev;/*points to the precceeding node*/

    }

    class DoubleLinkedlisT
    {
        node START;
        public DoubleLinkedlisT()
        {
            START = null;
        }
        public void addNode()/*Adds a new node*/
        {
            int dose;
            string nm;
            string id;
            string harga;
            Console.Write("\nMasukkan Dosis Obat : ");
            dose = Convert.ToInt32(System.Console.ReadLine());
            Console.Write("\nMasukkan Nama Obat : ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Id Obat : ");
            id = Console.ReadLine();
            Console.Write("\nMasukkan Harga Obat : ");
            harga = Console.ReadLine();
            node newnode = new node();
            newnode.dose = dose;
            newnode.name = nm;
            newnode.id = id;
            newnode.harga = harga;
            /*Checks if the list is empty*/
            if (START == null || dose <= START.dose)
            {
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;

            }
            node previous, current;
            for (current = previous = START; current != null &&
                dose >= current.dose; previous = current, current = current.next)
            {
                if (dose == current.dose)
                {
                    Console.WriteLine("\nData Terduplikasi");
                    return;
                }
            }
            /*On the execution of the above of the above for loop, prev and
             *current will point to those nodes
             between which the new node is to be inserted.*/
            newnode.next = current;
            newnode.prev = previous;

            /*If the node is to be inserted at the end of the list*/
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }

        /*Checks whether the specified node is present*/
        public bool Search(string nm, ref node previous, ref node current)
        {
            for (previous = current = START;
                current != null && nm != current.name;
                previous = current, current = current.next)
            { }
            /*The above for loop traverses the list. If the specified node
             is found then the function returns true, otherwise false.*/
            return (current != null);
        }
        public void traverse()/*Traverses the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong");
            else
            {
                Console.WriteLine("\nUrutan Obat Dari Dosis Terkecil " +
                    "sebagai berikut : \n");
                node currentnode;
                for (currentnode = START;
                    currentnode != null;
                    currentnode = currentnode.next)
                    Console.Write(currentnode.dose + " " + currentnode.id + " " + currentnode.name + " " + currentnode.harga + "\n");
            }
        }
        /*traverses the list in the reverse direction*/
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong");
            else
            {
                Console.WriteLine("\nUrutan Obat Dari Dosis Terbesar" +
                    "sebagai berikut :\n");
                node currentnode;
                for (currentnode = START;
                    currentnode.next != null;
                    currentnode = currentnode.next)
                { }
                while (currentnode != null)
                {
                    Console.Write(currentnode.dose + " " + currentnode.id + " " + currentnode.name + " " + currentnode.harga + "\n");
                    currentnode = currentnode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedlisT obj = new DoubleLinkedlisT();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Masukkan data obat" +
                        "\n 2. Melihat Data Obat Berdasarkan Dosis Terkecil" +
                        "\n 3. Melihat Data Obat Berdasarkan Dosis Terbesar" +
                        "\n 4. Mencari Obat" +
                        "\n 5. Exit \n" +
                        "\n Enter your choice (1-6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;

                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Nama Obat " +
                                    "yang ingin anda cari:");
                                string name = Console.ReadLine();
                                if (obj.Search(name, ref prev, ref curr) == false)
                                    Console.WriteLine("\nObat belum terdaftar");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nNama Obat : " + curr.name);
                                    Console.WriteLine("\nDosis Obat :" + curr.dose);
                                    Console.WriteLine("\nId Obat :" + curr.id);
                                    Console.WriteLine("\nHarga Obat :" + curr.dose);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }

}





/* JAWABAN SOAL NO 2-5 
 2. Saya memilih algoritma Double linked list, karena semua method yang diperlukan pada soal (mengurutkan mencari dan menampilkan) tersedia pada algoritma ini

 3. 
 
 4.

 5. A. 16,41,46,53,55,62,63,64,70,74
    B. Pre Order : 60,41,16,25,53,46,42,55,74,65,63,62,70,64
 */
