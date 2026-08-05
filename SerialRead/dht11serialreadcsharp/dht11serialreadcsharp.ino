#include <DHT.h>
#include <DHT_U.h>

#define Dht 2
#define Dhtype DHT11
DHT dht(Dht, Dhtype);
void setup() {
  Serial.begin(9600);
  dht.begin();
}

void loop() {
float temp =dht.readTemperature();
float hum=dht.readHumidity();
delay(2000);
Serial.println(temp);
Serial.println(hum);

}
