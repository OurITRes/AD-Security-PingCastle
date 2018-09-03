﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Text;

namespace PingCastle.Healthcheck.Rules
{
	[HeatlcheckRuleModel("A-PwdGPO", HealthcheckRiskRuleCategory.Anomalies, HealthcheckRiskModelCategory.PasswordRetrieval)]
	[HeatlcheckRuleComputation(RuleComputationType.PerDiscover, 20)]
    public class HeatlcheckRuleAnomalyPasswordInGPO : HeatlcheckRuleBase
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
			foreach (var pass in healthcheckData.GPPPassword)
			{
				AddRawDetail(pass.GPOName, pass.UserName, pass.Password);
			}
            return null;
        }
    }
}
