using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Web;
using System.Text;

namespace CalculatorService
{
    public class Calculator : ICalculator, ISilverlightClientAccessPolicy
    {
        public Calculation Add(Calculation data)
        {
            data.Result = data.Operand1 + data.Operand2;
            return data;
        }
        public Calculation Subtract(Calculation data)
        {
            data.Result = data.Operand1 - data.Operand2;
            return data;
        }
        public Calculation Multiply(Calculation data)
        {
            data.Result = data.Operand1 * data.Operand2;
            return data;
        }
        public Calculation Divide(Calculation data)
        {
            data.Result = data.Operand1 / data.Operand2;
            return data;
        }
        public Calculation SquareRoot(Calculation data)
        {
            data.Result = Math.Sqrt(data.Operand1);
            return data;
        }
        public string[] GetCalculationAudits()
        {
            throw new NotImplementedException();
        }
        public Stream GetClientAccessPolicy()
        {
            const string result =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <access-policy>
                                            <cross-domain-access>
                                                <policy>
                                                    <allow-from http-request-headers=""*"">
                                                        <domain uri=""*""/>
                                                    </allow-from>
                                                    <grant-to>
                                                        <resource path=""/"" include-subpaths=""true""/>
                                                    </grant-to>
                                                </policy>
                                            </cross-domain-access>
                                        </access-policy>";

            if (WebOperationContext.Current != null)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            }

            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        public string[] GetCaculationAudits()
        {
            throw new NotImplementedException();
        }
    }
}
