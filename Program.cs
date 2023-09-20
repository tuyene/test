using System;

class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo(int tuSo, int mauSo)
    {
        TuSo = tuSo;
        MauSo = mauSo;
    }

    public void InPhanSo()
    {
        if(MauSo < 0)
        {
            TuSo = -TuSo;
            MauSo = Math.Abs(MauSo);
        }
        Console.WriteLine("{0}/{1}", TuSo, MauSo);
    }

    public static PhanSo CongPhanSo(PhanSo ps1, PhanSo ps2)
    {
        int tuSo = ps1.TuSo * ps2.MauSo + ps2.TuSo * ps1.MauSo;
        int mauSo = ps1.MauSo * ps2.MauSo;
        return RutGonPhanSo(new PhanSo(tuSo, mauSo));
    }

    public static PhanSo TruPhanSo(PhanSo ps1, PhanSo ps2)
    {
        int tuSo = ps1.TuSo * ps2.MauSo - ps2.TuSo * ps1.MauSo;
        int mauSo = ps1.MauSo * ps2.MauSo;
        return RutGonPhanSo(new PhanSo(tuSo, mauSo));
    }

    public static PhanSo NhanPhanSo(PhanSo ps1, PhanSo ps2)
    {
        int tuSo = ps1.TuSo * ps2.TuSo;
        int mauSo = ps1.MauSo * ps2.MauSo;
        return RutGonPhanSo(new PhanSo(tuSo, mauSo));
    }

    public static PhanSo ChiaPhanSo(PhanSo ps1, PhanSo ps2)
    {
        int tuSo = ps1.TuSo * ps2.MauSo;
        int mauSo = ps1.MauSo * ps2.TuSo;

        // Kiểm tra phân số chia cho 0
        if (mauSo == 0)
        {
            throw new DivideByZeroException("Phan so khong the chia cho 0.");
        }

        return RutGonPhanSo(new PhanSo(tuSo, mauSo));
    }

    public static PhanSo RutGonPhanSo(PhanSo ps)
    {
        int gcd = TimUCLN(ps.TuSo, ps.MauSo);
        int tuSo = ps.TuSo / gcd;
        int mauSo = ps.MauSo / gcd;
        return new PhanSo(tuSo, mauSo);
    }

    public static int TimUCLN(int a, int b)
    {
        if (b == 0)
            return a;
        return TimUCLN(b, a % b);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nhap vao phan so thu nhat:");
        PhanSo ps1 = NhapPhanSo();

        Console.WriteLine("Nhap vao phan so thu hai:");
        PhanSo ps2 = NhapPhanSo();

        Console.WriteLine("Tong hai phan so:");
        PhanSo tong = PhanSo.CongPhanSo(ps1, ps2);
        tong.InPhanSo();

        Console.WriteLine("Hieu hai phan so:");
        PhanSo hieu = PhanSo.TruPhanSo(ps1, ps2);
        hieu.InPhanSo();

        Console.WriteLine("Tich hai phan so:");
        PhanSo tich = PhanSo.NhanPhanSo(ps1, ps2);
        tich.InPhanSo();

     
        Console.WriteLine("Thuong hai phan so:");
        PhanSo thuong = PhanSo.ChiaPhanSo(ps1, ps2);
         thuong.InPhanSo();
        
        
    }

    static PhanSo NhapPhanSo()
    {
        Console.Write("Nhap tu so: ");
        int tuSo = int.Parse(Console.ReadLine());
        Console.Write("Nhap mau so: ");
        int mauSo = int.Parse(Console.ReadLine());

        // Kiểm tra phân số bằng không
        if (mauSo == 0)
        {
            throw new ArgumentException("Mau so khong the bang 0.");
        }

        return new PhanSo(tuSo, mauSo);
    }
}