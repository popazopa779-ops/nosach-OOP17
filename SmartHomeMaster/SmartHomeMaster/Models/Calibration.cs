namespace SmartHomeMaster.Models;

public class Calibration : ICloneable
{
    public string PassportNumber { get; set; }
    public double Offset { get; set; }
    public DateTime CalibratedOn { get; set; }

    public Calibration(string passportNumber, double offset, DateTime calibratedOn)
    {
        PassportNumber = passportNumber;
        Offset = offset;
        CalibratedOn = calibratedOn;
    }

    public object Clone() => new Calibration(PassportNumber, Offset, CalibratedOn);

    public override string ToString() => $"{PassportNumber} (сдвиг {Offset:0.##}, {CalibratedOn:dd.MM.yyyy})";
}
