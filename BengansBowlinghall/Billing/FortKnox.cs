using System;
using System.Collections.Generic;
using BengansBowlinghall.Models;

namespace BengansBowlinghall.Billing
{
    public class FortKnox
    {
        private static FortKnox _instance;
        private readonly List<Invoice> _invoices;

        public FortKnox()
        {
            _invoices = new List<Invoice>();
        }

        public static FortKnox Instance()
        {
            return _instance ?? (_instance = new FortKnox());
        }

        public void NewInvoice(Member member, double debitAmount)
        {
            _invoices.Add(new Invoice(member, debitAmount));
        }

        public List<string> ExportInvoices()
        {
            var invoiceExport = new List<string>();

            Console.WriteLine("Exporting saved invoices...");
            foreach (var invoice in _invoices)
            {
                invoiceExport.Add(invoice.ToString());
                Console.WriteLine(invoice.ToString());
            }

            return invoiceExport;
        }
    }
}
