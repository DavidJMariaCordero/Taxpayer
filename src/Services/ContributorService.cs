using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Persistence.Models;
using Services.Base;

namespace Services
{
    public class ContributorService : BaseCrudService<Contributor>, IContributorService
    {
        public ContributorService(IContributorRepository ContributorRepository, IMapper mapper) : base(ContributorRepository, mapper)
        {
        }

        //public async Task<AppResponse<Tickets?>> PostDiagnostic(ServiceDiagnoseEvent diagnostic)
        //{
        //    var ticketId = 0;
        //    if (!string.IsNullOrEmpty(diagnostic.RequestMetadata.ReferenceId))
        //    {
        //        _ = int.TryParse(diagnostic.RequestMetadata.ReferenceId, out ticketId);
        //    }

        //    var ticket = await Repository.GetById(ticketId);
        //    if (ticket is null) return new DataNotFoundResponse<Tickets?>(default, $"Ticket : {diagnostic.RequestMetadata.ReferenceId}, Subscriber Number : {diagnostic.RequestMetadata.SubscriberNumber}");

        //    ticket.Facilities.Add(diagnostic.ServiceFacility, () => diagnostic.ServiceFacility is not null);
        //    if (diagnostic.PstnInformation is not null)
        //    {
        //        ticket.PstnInformations.Add(diagnostic.PstnInformation, () => diagnostic.PstnInformation is not null);
        //        ticket.PstnDiagnostics.Add(diagnostic.PstnInformation.PstnDiagnosticResult, () => diagnostic.PstnInformation.PstnDiagnosticResult is not null);
        //    }

        //    ticket.CopperTestDiagnostics.Add(diagnostic.DslamDiagnosticResult, () => diagnostic.DslamDiagnosticResult is not null);
        //    ticket.CopperTestResults.Add(diagnostic.DslamInformation, () => diagnostic.DslamInformation is not null);
        //    ticket.GponTestDiagnostics.Add(diagnostic.GponDiagnosticResult, () => diagnostic.GponDiagnosticResult is not null);
        //    ticket.GponTestResults.Add(diagnostic.GponInformation, () => diagnostic.GponInformation is not null);
        //    if (diagnostic.GponInformation is not null)
        //    {
        //        foreach (var sp in diagnostic.GponInformation.ServicePortsInformation)
        //        {
        //            ticket.GponTestResults.FirstOrDefault()?.ServicePortsInformation.Add(sp, () => diagnostic.GponInformation.ServicePortsInformation is not null);
        //        }
        //    }

        //    ticket.ServiceDiagnoseSummaries.Add(diagnostic.ServiceDiagnoseSummaries, () => diagnostic.ServiceDiagnoseSummaries is not null);

        //    // Service Status
        //    ticket.ConfigurationOk = diagnostic.ServiceDiagnoseSummaries.IsConfigurationOk;
        //    ticket.ParametersOk = diagnostic.ServiceDiagnoseSummaries.IsParametersOk;
        //    ticket.IsSynchronized = diagnostic.ServiceDiagnoseSummaries.IsSynchronized;
        //    ticket.IsServiceOk = (ticket.ConfigurationOk ?? false) && (ticket.ParametersOk ?? false) && (ticket.IsSynchronized ?? false);
        //    ticket.LastDiagnose = DateTime.Now;

        //    var result = await Repository.Update(ticket);
        //    return result.Succeeded switch
        //    {
        //        true => new AppSuccessResponse<Tickets?>(ticket),
        //        _ => new InternalErrorResponse<Tickets?>(ticket, result.Message)
        //    };
        //}
    }
}