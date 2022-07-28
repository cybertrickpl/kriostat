using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsl.Common.WebService.Measurement.UploadValues;
using WSL.DataBase.Repositores;

namespace Wsl.Services.Services
{
    public class MeasurementService
    {
        private readonly MeasurementRepository _measurementRepository;
        public MeasurementService(MeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        public UploadValuesResponse UploadValues(UploadValuesRequest request)
        {
            UploadValuesResponse response = new UploadValuesResponse();
            response.Id = _measurementRepository.UploadValues(request.FileContentBase64);
            return response;
        }

        
    }
}
