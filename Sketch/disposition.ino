/*

 Disposition
 ===========
 Serves as an interface between a computer and an Ikea dioder
 Find out more information at: https://github.com/holymoo/Disposition
 
 */

//////////////
// Settings
//////////////

int redPin = 11;      // The Pin that will be choosing the red color
int greenPin = 5;    // The Pin that will be choosing the green color
int bluePin = 3;     // The Pin that will be choosing the blue color

int redBrightness = 100;  // The value that will determine the brightness of the red color
int greenBrightness = 100; // The value that will determine the brightness of the green color
int blueBrightness = 100; // The value that will determine the brightenss of the blue color

int baudRate = 115200;

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

  if(Serial.available() > 0)
  {    
    // Parse out the data from the computer
    for(int x=0; x<protocolLength; x++)
    {
      receivedMessage[x] = Serial.read();
    }

    // Set the Brightness of the Red
    int redBrightness = receivedMessage[0];
    
    // Set the Brightness of the Green
    int greenBrightness = receivedMessage[1];
    
    // Set the Brightness of the Blue
    int blueBrightness = receivedMessage[2];
  }

  // Set the Dioder to the specified color
  analogWrite(redPin, redBrightness);
  analogWrite(greenPin, greenBrightness);
  analogWrite(bluePin, blueBrightness);  
}


