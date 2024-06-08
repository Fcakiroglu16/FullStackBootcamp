namespace SOLID.LSP;

public interface ITakePhoto
{
    void TakePhoto();
}

public abstract class BasePhone
{
    public void Call()
    {
        Console.WriteLine("call");
    }

    //public abstract void TakePhoto();
}

public class Nokia3310 : BasePhone
{
    //public override void TakePhoto()
    //{
    //    throw new NotImplementedException();
    //}
}

public class Iphone : BasePhone, ITakePhoto
{
//    public override void TakePhoto()
//    {
//        Console.WriteLine("Take Photo");
//    }
    public void TakePhoto()
    {
        Console.WriteLine("ıphone => Take Photo");
    }
}

public class XPhone : BasePhone, ITakePhoto
{
    //public override void TakePhoto()
    //{
    //    Console.WriteLine("Take Photo");
    //}
    public void TakePhoto()
    {
        Console.WriteLine("X => Take Photo");
    }
}