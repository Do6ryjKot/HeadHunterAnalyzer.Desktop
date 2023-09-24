﻿using Entities.DataTransferObjects;
using Entities.Models;

namespace Contracts.HeadHunterAnalyzer {
	
	/// <summary>
	/// Сервис взаимодействия с API.
	/// </summary>
	public interface IHeadHunterAnalyzerService {

		public Task<IEnumerable<WordStatisticsDto>> GetAllWords();

		public Task<AnalyzedVacancy> AnalyzeVacancy(int headHunterId);
	}
}
