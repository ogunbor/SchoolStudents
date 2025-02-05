﻿using Contracts;
using Service.Contracts;


namespace Service
{
    internal sealed class SchoolService : ISchoolService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public SchoolService(IRepositoryManager repository, ILoggerManager logger)
        { _repository = repository; _logger = logger; }
    }

}
