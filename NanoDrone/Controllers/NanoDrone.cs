﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoDrone.Sensors;
using System.Diagnostics;
using Windows.Devices.Gpio;
using System.Threading;
using Adafruit.Pwm;

namespace NanoDrone.Controllers
{
    public class NanoDrone : Drone
    {
        private MotorController motorController;
        private OrientationController orientationController;
        private CommunicationController communicationController;
        public MotorController MotorController
        {
            get
            {
                return motorController;
            }
        }
        public OrientationController OrientationController
        {
            get
            {
                return orientationController;
            }
        }
        public CommunicationController CommunicationController
        {
            get
            {
                return communicationController;
            }
        }

        public NanoDrone()
        {

            orientationController = new OrientationController(this);
            motorController = new MotorController(this);
            communicationController = new CommunicationController(this);

        }

        ~NanoDrone()
        {
            this.Stop();
        }

        public void Stop()
        {
            this.motorController.Shutdown();
        }

        public void Start()
        {
            this.motorController.Start();
        }
    }
}
