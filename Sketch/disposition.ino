
int led = 11;          // the pin that the LED is attached to
int brightness = 10;    // how bright the LED is

// the setup routine runs once when you press reset:
void setup()  { 
  Serial.begin(115200);
  pinMode(led, OUTPUT);
} 

// the loop routine runs over and over again forever:
void loop()  { 
  
  if(Serial.available() > 0)
  {
    brightness = Serial.parseInt();
  }
  
  // set the brightness of pin 11:
  analogWrite(led, brightness);                               
}

