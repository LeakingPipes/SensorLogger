// Sleep tid
uint64_t uS_TO_S_FACTOR = 1000000;  // Micro sekunder to sekunder
// 900 sekunder = 15 minutter
uint64_t TIME_TO_SLEEP = 900;

void startSleep(){
  #ifdef ESP32
    esp_sleep_enable_timer_wakeup(TIME_TO_SLEEP * uS_TO_S_FACTOR);    
    Serial.println("Going to sleep now");
    esp_deep_sleep_start();
  #else
    Serial.println("Going to sleep now");
    ESP.deepSleep(TIME_TO_SLEEP * uS_TO_S_FACTOR); 
  #endif
}
