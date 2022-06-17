var devices = new List<IDevice>
{
    new PciDevice(),
    new NetworkDevice(),
    new UsbDevice(),
};

foreach (var device in devices)
{
    device.Open();
    //device.Refresh();// only usdDevice need this, why call this method for every other device??
}

internal interface IDevice
{
    void Open();
    void Read();
    void Close();
    void Refresh(); // wrong solution!!! specific only to USB interface Device
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

    public void Refresh()
    {
        throw new NotImplementedException();
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

    public void Refresh()
    {
        throw new NotImplementedException();
    }
}

internal class UsbDevice : IDevice
{
    /*
     * The problem with a USB device is that when you open the connection,
     * data from the previous connection remains in the buffer. Therefore,
     * upon the first read call to the USB device, data from the previous session is returned.
     * That behavior corrupted data for that particular acquisition session.
     *
     * Fortunately, a USB-based device driver provides a refresh function which
     * clears the buffers in the USB-based acquisition device.
     */
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
        // specific only to USB interface Device
        Console.WriteLine("UsbDevice Refresh method was called.");
    }
}