void getReading() {
  temperature = dht.readTemperature();
  humidity = dht.readHumidity();

  //char buf[30];
  //sprintf(buf, "Temperature is %t and humidity is %h", temperature, humidity);

  delay(2000);

  Serial.print("Temperature is ");
  Serial.print(temperature);

  Serial.print(" and humidity is ");
  Serial.print(humidity);
  Serial.print(".");
}
