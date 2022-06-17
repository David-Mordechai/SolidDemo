// SRP - handle only standard devices
var standardDevices = new List<IStandardDevice>
{
    new PciDevice(),
    new NetworkDevice()
};
foreach (var standardDevice in standardDevices)
{
    standardDevice.Open();
}

// SRP - handle only usb devices
var usbDevices = new List<IUsbDevice>
{
    new UsbDevice(),
};
foreach (var usbDevice in usbDevices)
{
    usbDevice.Open();
    usbDevice.Refresh();
}

// IStandardDevice and IUsbDevice are similar BUT NOT THE SAME
// therefor they cannot substitute each other and this is violation of LSP
// The best way to solve this is by divide them to different types

internal interface IStandardDevice
{
    void Open();
    void Read();
    void Close();
}

internal interface IUsbDevice
{
    void Open();
    void Read();
    void Close();
    void Refresh();
}

internal class PciDevice : IStandardDevice
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

internal class NetworkDevice : IStandardDevice
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