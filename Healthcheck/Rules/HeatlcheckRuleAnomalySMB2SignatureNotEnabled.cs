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
	[HeatlcheckRuleModel("A-SMB2SignatureNotEnabled", HealthcheckRiskRuleCategory.Anomalies, HealthcheckRiskModelCategory.NetworkSniffing)]
	[HeatlcheckRuleComputation(RuleComputationType.TriggerOnPresence, 5)]
    public class HeatlcheckRuleAnomalySMB2SignatureNotEnabled : HeatlcheckRuleBase
	{
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
		{
			foreach (var DC in healthcheckData.DomainControllers)
			{
				if (DC.SupportSMB2OrSMB3)
				{
					if (DC.SMB2SecurityMode != SMBSecurityModeEnum.NotTested)
					{
						if ((DC.SMB2SecurityMode & SMBSecurityModeEnum.SmbSigningEnabled) == 0)
						{
							AddRawDetail(DC.DCName);
						}
					}
				}
			}
			return null;
		}
	}
}
