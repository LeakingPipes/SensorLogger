// Includes
#include <HTTPClient.h>
#include <DHT.h>
#include "config.h"

#ifdef ESP32
  #include <WiFi.h>
#else
  #include <ESP8266WiFi.h>
#endif

#define DHTPIN 23
#define DHTTYPE    DHT11

DHT dht(DHTPIN, DHTTYPE);

float temperature;
float humidity;

void setup() {
  Serial.begin(115200);
  dht.begin();
  delay(500);

  startWifi();
  getReading();
  sendReading();
  startSleep();
}


void loop() {
  // Bliver ikke brugt
}
