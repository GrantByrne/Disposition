Disposition
===========

C#/Arduino interface for the IKEA Dioder to create mood lighting for the back of your monitor!

**Note: This project is currently in a semi-working state. Use at your own risk.**

Eye Candy
---------
**Example of it handling a javascript rainbow transition**

[![Rainbow Behind Monitor](http://img.youtube.com/vi/AczCC4aMguo/0.jpg)](http://www.youtube.com/watch?v=AczCC4aMguo)

Parts List
----------

**Required Parts**
- [Arduino Duemilanove](http://arduino.cc/en/Main/arduinoBoardDuemilanove) (or better)
- [IKEA Dioder](http://www.ikea.com/us/en/catalog/products/50192365/)
- [Soldering Iron](http://www.amazon.com/Soldering-Station-Features-Continuously-Variable/dp/B0029N70WM/ref=sr_1_2?ie=UTF8&qid=1382397412&sr=8-2&keywords=soldering+iron)
- [Solder](http://www.amazon.com/Amico-0-3mm-Rosin-Solder-Soldering/dp/B008DEYEAW/ref=sr_1_4?ie=UTF8&qid=1382397509&sr=8-4&keywords=rosin+solder)
- Small Screwdriver (to take apart the Dioder Controller)
- Wires/Jumpers

**Recommended Parts**
- [Breadboard](http://www.amazon.com/microtivity-400-point-Experiment-Breadboard-Jumper/dp/B004RXKWDQ/ref=sr_1_3?ie=UTF8&qid=1382397570&sr=8-3&keywords=breadboard)
- Some LED's (for testing)

Setting Up the Arduino
----------------------

1. Download the Arduino IDE: [Here](http://arduino.cc/en/Main/Software)
2. Open up .\Arduino\disposition\disposition.ino in the Arduino IDE.
3. Upload the Sketch to the Arduino

Connecting the Arduino to the Dioder
------------------------------------

*Coming Soon!*

Project Architecture
--------------------

- **Application:** Contains all the code to Interface with the Arduino in Windows.
  - **ArduinoTest.Components:** Contains the framework for interacting with the arduino and the screen.
  - **ArduinoTest.Tests:** Houses the Unit/Integration/Performance tests for the project.
  - **ArduinoTest.Winform:** Minor application that was used for initial testing of components. *Will Be Phased Out.*
  - **ArduinoTest.Wpf:** Will contain the main application for using and configuring the system.
- **Arduino:** Houses the Sketch for the ArduinoBoard.
