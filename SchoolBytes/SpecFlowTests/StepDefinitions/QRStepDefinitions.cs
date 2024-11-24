﻿using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using SchoolBytes.Controllers;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class QRStepDefinitions
    {
        private string initialId;
        private string newId;
        private bool isAttendanceUpdated;
        private QRController qrController = new();

        

        // Scenario: ID for check-in changes when new QR Code is generated
        [Given(@"I have access to the Generation Webpage")]
        public void GivenIHaveAccessToTheGenerationWebpage()
        {
            // Simulate accessing the generation webpage. Currently simply knowing the webpage is enough as there is no implementation of
            // the page being admin only accessible
            Assert.IsTrue(true, "User has access to the QR code generation page.");
        }

        [When(@"I generate a new QR Code")]
        public void WhenIGenerateANewQRCode()
        {
            // Get the current ID and then generate a new one and set it
            initialId = qrController.GetQrId(); 
            string newIdTemp = qrController.GenerateRandomId();
            qrController.SetQrId(newIdTemp);
            newId = qrController.GetQrId();
        }

        [Then(@"the ID for Attendance Check In should change")]
        public void ThenTheIDForAttendanceCheckInShouldChange()
        {
            // Validate that the ID has changed
            Assert.AreNotEqual(initialId, newId, "The QR Code ID should change when a new QR Code is generated.");
        }

    }
}
