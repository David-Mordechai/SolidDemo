var devices = new List<IDevice>
{
    new PciDevice(),
    new NetworkDevice(),
    new UsbDevice(),
};

foreach (var device in devices)
{
    device.Open();
 
    // not very good practice to ask actor what type he is
    // better if actor tell us about him self
    if(device is IUsbDevice usbDevice)
        usbDevice.Refresh();
}

internal interface IDevice
{
    void Open();
    void Read();
    void Close();
}

internal interface IUsbDevice : IDevice
{
    void Refresh();
}

internal class PciDevice : IDevice
{
    public void Open()
    {
        Console.WriteLine("PciDevice Open method was called.");
    }

    public void Read()
    {
        Console.WriteLine("PciDevice Close method was called.");
    }

    public void Close()
    {
        Console.WriteLine("PciDevice Close method was called.");
    }
}

internal class NetworkDevice : IDevice
{
    public void Open()
    {
        Console.WriteLine("NetworkDevice Open method was called.");
    }

    public void Read()
    {
        Console.WriteLine("NetworkDevice Close method was called.");
    }

    public void Close()
    {
        Console.WriteLine("NetworkDevice Close method was called.");
    }
}

internal class UsbDevice : IUsbDevice
{
    public void Open()
    {
        Console.WriteLine("UsbDevice Open method was called.");
    }

    public void Read()
    {
        Console.WriteLine("UsbDevice Close method was called.");
    }

    public void Close()
    {
        Console.WriteLine("UsbDevice Close method was called.");
    }

    public void Refresh()
    {
        Console.WriteLine("UsbDevice Refresh method was called.");
    }
}
