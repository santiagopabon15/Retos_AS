using System;

public interface IMetodoPago
{
    void Procesar();
}

public class TarjetaCredito : IMetodoPago
{
    public string NumeroTarjeta { get; }
    public string NombreTitular { get; }
    public string FechaExpiracion { get; }
    public double Monto { get; }

    public TarjetaCredito(string numero, string titular, string expiracion, double monto)
    {
        NumeroTarjeta = numero;
        NombreTitular = titular;
        FechaExpiracion = expiracion;
        Monto = monto;
    }

    public void Procesar()
    {
        Console.WriteLine($"Procesando pago con Tarjeta de Crédito. Monto: {Monto}");
        Console.WriteLine($"Tarjeta: {NumeroTarjeta} - Titular: {NombreTitular}");
    }
}

public class PayPal : IMetodoPago
{
    public string Correo { get; }
    public string Contraseña { get; }
    public double Monto { get; }

    public PayPal(string correo, string contraseña, double monto)
    {
        Correo = correo;
        Contraseña = contraseña;
        Monto = monto;
    }

    public void Procesar()
    {
        Console.WriteLine($"Procesando pago con PayPal. Monto: {Monto}");
        Console.WriteLine($"Correo asociado: {Correo}");
    }
}

public class TransferenciaBancaria : IMetodoPago
{
    public string NumeroCuenta { get; }
    public string Banco { get; }
    public double Monto { get; }

    public TransferenciaBancaria(string cuenta, string banco, double monto)
    {
        NumeroCuenta = cuenta;
        Banco = banco;
        Monto = monto;
    }

    public void Procesar()
    {
        Console.WriteLine($"Procesando pago con Transferencia Bancaria. Monto: {Monto}");
        Console.WriteLine($"Cuenta: {NumeroCuenta} - Banco: {Banco}");
    }
}

public class Bitcoin : IMetodoPago
{
    public string Wallet { get; }
    public double Monto { get; }

    public Bitcoin(string wallet, double monto)
    {
        Wallet = wallet;
        Monto = monto;
    }

    public void Procesar()
    {
        Console.WriteLine($"Procesando pago con Bitcoin. Monto: {Monto}");
        Console.WriteLine($"Wallet: {Wallet}");
    }
}

public class ProcesadorPagos
{
    public void ProcesarPago(IMetodoPago metodoPago)
    {
        metodoPago.Procesar();
    }
}

class Program
{
    static void Main()
    {
        ProcesadorPagos procesador = new ProcesadorPagos();
        
        IMetodoPago tarjeta = new TarjetaCredito("1234-5678-9876-5432", "Juan Pérez", "12/27", 100.50);
        IMetodoPago paypal = new PayPal("juan.perez@example.com", "secreto123", 75.30);
        IMetodoPago transferencia = new TransferenciaBancaria("0987654321", "Banco XYZ", 200.00);
        IMetodoPago bitcoin = new Bitcoin("1A2b3C4d5E6f7G8h9I0J", 300.00);
        
        procesador.ProcesarPago(tarjeta);
        procesador.ProcesarPago(paypal);
        procesador.ProcesarPago(transferencia);
        procesador.ProcesarPago(bitcoin);
    }
}
