#include "AtomWire.h"
//#define DEBUG_SERIAL 1

OneWire awm(13); 
OneWire awm2(12);
OneWire awm3(11); 

int c= 0;
int counter = 0;
int level = 0;


bool cycle = false;

void setup(void) {
  Serial.begin(9600); 
}

void loop(void) {
  
  byte i;
  byte present = 0;
  byte data[12];
  byte addr[8];
  
  switch(level){
    case 0:
      if (!awm.search(addr)) {
        //Serial.print("\nNo further Slaves Detected 1.\n");
        awm.reset_search();
        level = 1;
        return;
      }
#ifdef DEBUG_SERIAL
      Serial.print("\nAddress = ");
      for(i = 0; i < 8; i++) {
        Serial.print(addr[i], HEX);
        Serial.print(" ");
      }
#endif
      
      if ( addr[0] == 0x3A) {
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice belongs to AtomWire family.");
        #endif
      }else {
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice family is not recognized.");
        #endif   
        return;
      }
      
      #ifdef DEBUG_SERIAL
      delay(1485);     
      #endif 
      delay(15);
 
      //Reading scratchpad data - Block, Node IDs as well as GPIO input pins.
      present = awm.reset();
      awm.select(addr);  

      awm.write(0xA2); 
      //Serial.print("P = ");
      #ifdef DEBUG_SERIAL
      Serial.print("\nP =");
      Serial.print(present,HEX);
      Serial.print(" ");
      #endif
      for ( i = 0; i < 9; i++) {           // we need 9 bytes
        data[i] = awm.read();
        #ifdef DEBUG_SERIAL
        Serial.print(data[i], HEX);
        Serial.print(" ");
        #endif
      }
      #ifdef DEBUG_SERIAL
      Serial.print("\nCounter = ");
      Serial.print(data[4], HEX);
      Serial.print("\nCRC = ");
      Serial.print( OneWire::crc8( data, 8), HEX);
      Serial.print("\nCoordinates = 4");
      Serial.print("\r\n");
      #else
      Serial.print("P = ");
      Serial.print(addr[1], HEX);
      Serial.print(" 1\r\n");
      #endif
      c++ ; 
      break;
  
    case 1:
      if (!awm2.search(addr)) {
      //Serial.print("\nNo further Slaves Detected 2.\n");
      awm2.reset_search();   
      level = 2;
      return;
      }
#ifdef DEBUG_SERIAL
      Serial.print("\nAddress = ");
      for(i = 0; i < 8; i++) {
        Serial.print(addr[i], HEX);
        Serial.print(" ");
      }
#endif
      
      if ( addr[0] == 0x3A){ 
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice belongs to AtomWire family.");
        #endif
      }else {
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice family is not recognized.");
        #endif  
        return;
      }
     
      #ifdef DEBUG_SERIAL
      delay(1485);     
      #endif 
      delay(15);
      //Reading scratchpad data - Block, Node IDs as well as GPIO input pins.
      present = awm2.reset();
      awm2.select(addr);  
      awm2.write(0xA2); 
      //Serial.print("P = ");
      #ifdef DEBUG_SERIAL
      Serial.print("\nP = ");
      Serial.print(present,HEX);
      Serial.print(" ");
      #endif
      for ( i = 0; i < 9; i++) {           // we need 9 bytes
        data[i] = awm2.read();
        #ifdef DEBUG_SERIAL
        Serial.print(data[i], HEX);
        Serial.print(" ");
        #endif
      }
      #ifdef DEBUG_SERIAL
      Serial.print("\nCounter = ");
      Serial.print(data[4], HEX);
      Serial.print("\nCRC = ");
      Serial.print( OneWire::crc8( data, 8), HEX);
      Serial.print("\nCoordinates = 0");
      Serial.print("\r\n");
      #else
      Serial.print("P = ");
      Serial.print(addr[1], HEX);
      Serial.print(" 2\r\n");
      #endif  
  
      c++ ; 
      break;

    case 2:
      if (!awm3.search(addr)) {
        //Serial.print("\nNo further Slaves Detected 1.\n");
        awm3.reset_search();
        level = 0;
        return;
      }
#ifdef DEBUG_SERIAL
      Serial.print("\nAddress = ");
      for(i = 0; i < 8; i++) {
        Serial.print(addr[i], HEX);
        Serial.print(" ");
      }
#endif
      
      if ( addr[0] == 0x3A) {
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice belongs to AtomWire family.");
        #endif
      }else {
        #ifdef DEBUG_SERIAL
        Serial.print("\nDevice family is not recognized.");
        #endif   
        return;
      }
      
      #ifdef DEBUG_SERIAL
      delay(1485);     
      #endif 
      delay(15);
 
      //Reading scratchpad data - Block, Node IDs as well as GPIO input pins.
      present = awm3.reset();
      awm3.select(addr);  

      awm3.write(0xA2); 
      //Serial.print("P = ");
      #ifdef DEBUG_SERIAL
      Serial.print("\nP =");
      Serial.print(present,HEX);
      Serial.print(" ");
      #endif
      for ( i = 0; i < 9; i++) {           // we need 9 bytes
        data[i] = awm3.read();
        #ifdef DEBUG_SERIAL
        Serial.print(data[i], HEX);
        Serial.print(" ");
        #endif
      }
      #ifdef DEBUG_SERIAL
      Serial.print("\nCounter = ");
      Serial.print(data[4], HEX);
      Serial.print("\nCRC = ");
      Serial.print( OneWire::crc8( data, 8), HEX);
      Serial.print("\nCoordinates = 5");
      Serial.print("\r\n");
      #else
      Serial.print("P = ");
      Serial.print(addr[1], HEX);
      Serial.print(" 3\r\n");
      #endif
      c++ ; 
      break;    
        
    } //switch
} //void loop
