/*

 Disposition
 ===========
 Serves as an interface between a computer and an Ikea dioder
 Find out more information at: https://github.com/holymoo/Disposition
 
 */

//////////////
// Settings
//////////////

int redPin = 5;      // The Pin that will be choosing the red color
int greenPin = 3;    // The Pin that will be choosing the green color
int bluePin = 11;     // The Pin that will be choosing the blue color

byte redBrightness = 255;  // The value that will determine the brightness of the red color
byte greenBrightness = 255; // The value that will determine the brightness of the green color
byte blueBrightness = 255; // The value that will determine the brightenss of the blue color

int baudRate = 9600;

//////////////
// Fields
//////////////

int protocolLength = 3;
byte receivedMessage[3];

//////////////
// Logic
//////////////

// the setup routine runs once when you press reset:
void setup()  { 

  // Allow the arduino to be connected to
  Serial.begin(baudRate);

  // Set up the Pins for the colors
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
} 

// the loop routine runs over and over again forever:
void loop()  { 

  if(Serial.available() == 3)
  {    
    // Set the Brightness of the Red
    redBrightness = Serial.read();
    
    // Set the Brightness of the Green
    greenBrightness = Serial.read();
    
    // Set the Brightness of the Blue
    blueBrightness = Serial.read();
  }

  // Set the Dioder to the specified color
  analogWrite(redPin, redBrightness);
  analogWrite(greenPin, greenBrightness);
  analogWrite(bluePin, blueBrightness);  
}


