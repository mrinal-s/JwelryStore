using jewelrystoreAPI.Mappers;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace jewelrystoreAPI
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        #region Constructor
        private readonly IUserDataAccess _userDataRepository;
        public UserBusinessLogic(IUserDataAccess userDataAccess)
        {
            _userDataRepository = userDataAccess;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get user information based on userName & password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JwelleryCost GetUser(User user)
        {
            var getUserData = _userDataRepository.GetUserData(user);
            return JwellweryCostMapper.MapToJwelleryCost(getUserData);

        }

        /// <summary>
        /// If IsFilePrint= true it will print to file else into pdf
        /// </summary>
        /// <param name="jwl"></param>
        /// <returns></returns>
        public bool PrintUser(JwelleryCost jwl)
        {
           try
            {               
                if (jwl != null)
                {
                    switch (jwl.IsFilePrint)
                    {
                        case true:
                            this.Printtofile(jwl);
                            break;
                        case false:
                            this.PrintPDF(jwl);                            
                            break;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Private Method
        private JwelleryCost Printtofile(JwelleryCost jwl)
        {
            try
            {
                if (jwl != null)
                {
                    using (StreamWriter writer = System.IO.File.CreateText("logfile.txt"))
                    {
                        writer.WriteLine("GoldPrice:" + jwl.GoldPrice);
                        writer.WriteLine("GoldWeight:" + jwl.GoldWeight);
                        writer.WriteLine("Discount:" + jwl.Discount);
                        writer.WriteLine("TotalPrice:" + jwl.TotalPrice);

                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }


            return jwl;

        }
        private JwelleryCost PrintPDF(JwelleryCost jwl)
        {
            try
            {
                if (jwl != null)
                {
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = "Jwelery Store";
                    PdfPage pdfPage = pdf.AddPage();
                    XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                    XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
                    graph.DrawString("GoldPrice :"+ jwl.GoldPrice.ToString()+ "GoldWeight :"+jwl.GoldWeight.ToString() + "TotalPrice :" + jwl.TotalPrice.ToString() , font, XBrushes.Black, new XRect(10, 10, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
                    string pdfFilename = "JweleryStore.pdf";
                    pdf.Save(pdfFilename);
                    Process.Start(pdfFilename);
                }
            }
           
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            return jwl;

        }
        #endregion
    }
}
