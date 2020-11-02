using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace ModeloTesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe responsável por gerênciar a criação e o salvamento do relatóio de teste.
    /// </summary>
    public static class CriaRelatorioHelper
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static readonly string dir = "C:";
        private static readonly string nomeDaPasta = "\\Reporte_De_Testes\\";
        private static readonly string nomeReport = "\\Autorização.html";

        /// <summary>
        /// Método responsável por criar o relatório.
        /// </summary>
        /// <param name="nomeSuite">Nome da suíte de teste que nomeára a pasta onde o report será salvo.</param>
        public static void CriaRelatorio(string nomeSuite)
        {
            try
            {
                _extent = new ExtentReports();
                DirectoryInfo di = Directory.CreateDirectory(dir + nomeDaPasta + DateTime.Now.ToString("MM-yy") + "\\" + nomeSuite);
                var htmlReport = new ExtentHtmlReporter(di.FullName + nomeReport);
                htmlReport.Config.EnableTimeline = false;
                _extent.AddSystemInfo(".NET C#", "Projeto de teste automatizado");
                _extent.AddSystemInfo("Usuário", "Marcelo");
                _extent.AttachReporter(htmlReport);
            }
            catch (Exception e)
            {
                throw new Exception($"Não foi possível criar o relatorio da suite {nomeSuite}");
            }
        }

        /// <summary>
        /// Método responsável por finalizar o relatório de teste.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public static void FinalizaRelatorio(IWebDriver driver)
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = CapturaImagensHelper.CapturaPrintTela(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;

                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;

                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível finalizar o relatório");
            }
        }

        /// <summary>
        /// Método responsável por criar o text context.
        /// </summary>
        public static void CriaTeste()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Método responsável por gravar no arquivo do relatório.
        /// </summary>
        public static void GravaNoRelatorio()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível gravar no arquivo");
            }
        }
    }
}