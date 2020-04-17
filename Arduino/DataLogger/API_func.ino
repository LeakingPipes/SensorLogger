void sendReading(){
  if(WiFi.status()== WL_CONNECTED){
      HTTPClient http;
      http.begin(serverName);

      http.addHeader("Content-Type", "application/json");      
      String json = String("{\"microcontrollerID\":\"") + microcontrollerID + "\",\"readingValues\":[{\"value\":\"" + temperature + "\",\"valueType\":\"C\"},{\"value\":\"" + humidity + "\",\"valueType\":\"Procent\"}]}";
      int httpResponseCode = http.POST(json);
      
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      
      http.end();
      }
      else {
        Serial.println("Connection error");
    }
  }
