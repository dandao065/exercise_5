using System.ComponentModel;
using System.Xml.Linq;

internal class Exercise_05
{
    static void Main()
    {
        Random rnd = new Random();
        int[] a = new int[10];
        Console.WriteLine("Muoi so ngau nhien");
        for (int i = 0; i < 10; i++)
        {
            a[i] = rnd.Next(0, 100);
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"1. Trung binh cong cua 10 so la: {avg_value(a)}");

        Console.WriteLine("\n2. Nhap so ban muon kiem tra co trong day khong.");
        Console.Write("So ban muon kiem tra la: ");
        int spe_val = Convert.ToInt32(Console.ReadLine());
        if (contain_val(a, spe_val))
        {
            Console.WriteLine("CO");
        }
        else
        {
            Console.WriteLine("KHONG");
        }

        Console.WriteLine("\n3. Tim vi tri cua mot so.");
        Console.Write("Nhap so ban muon tim: ");
        int val = Convert.ToInt32(Console.ReadLine());
        int index = index_ele(a, val);
        if (index != -1)
        {
            Console.WriteLine($"So {val} nam o vi tri {index + 1}");
        }
        else
        {
            Console.WriteLine($"Khong co {val} trong day so");
        }

        Console.WriteLine("\n4. Xoa 1 so khoi day.");
        Console.Write("Nhap so ban muon xoa: ");
        int remove_val = Convert.ToInt32(Console.ReadLine());
        int[] new_array = remove(a, remove_val);
        Console.Write("Mang luc sau: ");
        foreach(int x in new_array)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\n5. Tim gia tri lon nhat va be nhat.");
        var (max, min) = max_min(a);
        Console.WriteLine($"Gia tri lon nhat la: {max} \nGia tri be nhat la: {min}");

        Console.WriteLine("\n6. Dao nguoc thu tu cac so trong mang.");
        Console.Write("Mang sau khi dao chieu: ");
        reverse( a );

        Console.WriteLine("\n7. Tim so lap lai trong mang.");
        Console.Write("Xep lai theo thu tu: ");
        Array.Sort(a);
        foreach (int i in a)
            Console.Write(i+ " ");
        Console.WriteLine();
        Console.Write("So lap lai trong mang la: ");
        duplicate(a);

        Console.WriteLine("\n8. Xoa so trung khoi mang.");
        int[] new_rem = remove_dup(a);
        if (new_rem.Length != a.Length)
        {
            Console.Write("Mang moi la: ");
            foreach (int j in new_rem)
                Console.Write(j + " ");
        }
        else
            Console.WriteLine("Mang giu nguyen");

        // 1.to calculate the average value of array elements.
        static double avg_value(int[] a)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            double avg = sum / a.Length;
            return avg;
        }

        // 2.to test if an array contains a specific value.
        static bool contain_val (int [] a, int spe_val)
        {
            foreach (int i in a)
            {
                if (i == spe_val)
                {
                    return true; // Tìm được i
                }
            }
            return false;
        }
        // 3.to find the index of an array element.
        static int index_ele (int [] a, int val)
        {
            for (int i=0; i < a.Length; i++)
            {
                if (a[i]==val)
                {
                    return i;
                }
            }
            return -1; //nếu không thấy
        }
        // 4.to remove a specific element from an array.
        static int[] remove (int [] a, int val)
        {
            int index=Array.IndexOf(a, val);
            if (index == -1)
                return a;
            int[] newarray=new int[a.Length-1];
            int x = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i == index)
                    continue;
                newarray[x++]= a[i];
            }
            return newarray;
        }

        // 5.to find the maximum and minimum value of an array.
        static (int, int) max_min(int [] a)
        {
            int max = a[0];
            int min = a[0];
            foreach (int i in a)
            {
                if (i > max) { max = i; }
                if (i < min) { min = i; }
            }
            return (max, min);
        }

        // 6.to reverse an array of integer values.
        static void reverse (int [] a)
        {
            for (int i=a.Length-1; i>=0; i--)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        // 7.to find duplicate values in an array of values.
        static void duplicate (int[]a)
        {
            Array.Sort(a);
            int count = 0;
            for (int i = 1;i < a.Length;i++)
            {
                if ((a[i] == a[i - 1]) && (count == 0 || a[i] != a[i - 2]))
                {
                    Console.Write(a[i]+ " ");
                    count++;
                }
            }
            if (count==0)
            {
                Console.WriteLine("Khong co.");
            }
            else Console.WriteLine();
        }

        // 8.to remove duplicate elements from an array.
        static int[] remove_dup(int[]a)
        {
            int[] rem = new int[a.Length];
            int count = 0;
            for (int i=1; i<a.Length; i++)
            {
                if (a[i] != a[i - 1])
                {
                    rem[count++] = a[i - 1];
                }
            }
            rem[count++] = a[a.Length - 1];

            if (count == a.Length)
            {
                return a;
            }
            else
            {
                Array.Resize(ref rem, count);
                return rem;
            }
        }
    }
}
