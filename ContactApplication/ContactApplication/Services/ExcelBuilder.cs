using ContactApplication.Models;
using OfficeOpenXml;

namespace ContactApplication.Services
{
    public class ExcelBuilder
    {
        public ExcelBuilder() {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public byte[] BuildExcel(List<Person> people)
        {
            Dictionary<string,int> LocationPerson = new Dictionary<string,int>();
            Dictionary<string, int> LocationPhone = new Dictionary<string, int>();
            foreach (Person person in people)
            {
                foreach(ContactInformation contactInformation in person.ContactInformation)
                {
                    if (!LocationPerson.ContainsKey(contactInformation.Location))
                    {
                        LocationPerson.Add(contactInformation.Location, 1);

                        if (!String.IsNullOrEmpty(contactInformation.PhoneNumber))
                        {
                            if (!LocationPhone.ContainsKey(contactInformation.Location))
                            {
                                LocationPhone.Add(contactInformation.Location, 1);
                            }
                            else
                            {
                                LocationPhone[contactInformation.Location] += 1;
                            }
                            
                        }
                    }
                    else
                    {
                        LocationPerson[contactInformation.Location] += 1;

                        if (!String.IsNullOrEmpty(contactInformation.PhoneNumber))
                        {
                            if (!LocationPhone.ContainsKey(contactInformation.Location))
                            {
                                LocationPhone.Add(contactInformation.Location, 1);
                            }
                            else
                            {
                                LocationPhone[contactInformation.Location] += 1;
                            }

                        }
                    }
                }
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");

                worksheet.Cells["A1"].Value = "Location";
                worksheet.Cells["B1"].Value = "Person Count";
                worksheet.Cells["C1"].Value = "Phone Count";


                int row = 2;
                foreach (var item in LocationPerson)
                {
                    worksheet.Cells["A" + row].Value = item.Key;
                    worksheet.Cells["B" + row].Value = item.Value;
                    worksheet.Cells["C" + row].Value = LocationPhone[item.Key];
                    row++;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();

                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin);


                    return stream.ToArray();
                }
            }
            return null;
        }
    }
}
