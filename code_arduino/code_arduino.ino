#include <LiquidCrystal.h>

String inputString = "";
String workString = "Ready to Connect";
String commandString = "";
boolean stringComplete = false;

boolean isConnected = false;

LiquidCrystal lcd(12,11,5,4,3,2); 


void setup() {
  Serial.begin(9600);
  
  lcd.begin(16, 2);
  lcd.print("Ready to connect!");
}

void loop() {
  if(stringComplete)
    {
      stringComplete = false;
      getCommand();
    
      if(commandString.equals("STAR"))
      {
        lcd.clear();
      }
      if(commandString.equals("STOP"))
      {
        lcd.clear();
        lcd.print("Ready to connect!");
      }
      else if(commandString.equals("TEXT"))
      {
       workString = getText();
       printText(workString);
      }  
      inputString = "";
    }
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    inputString += inChar;
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

String getText()
{
  String value = inputString.substring(5,inputString.length()-2);
  return value;
}

void printText(String text)
{
  lcd.clear();
    if(text.length()<16)
    {
      lcd.print(text);
    }else if(text.length()<32)
    {
      lcd.print(text.substring(0,16));
      lcd.setCursor(0,1);
      lcd.print(text.substring(16,32));
      lcd.setCursor(0,0);
    }else
    {
      for(int i=0;i+16<text.length();i++)
      {
        lcd.clear();
        lcd.print(text.substring(i,i+16));
        delay(1000);
      }
    }
}
