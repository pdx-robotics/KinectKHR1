
#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>

#define DMAX 530
#define DMIN 160
#define FREQ 60
#define MAP(d) map(d,0,180, DMIN, DMAX)
#define DWRITE(channel, d) pwm.setPWM(channel,0,MAP(d))

Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver();

#define SERVOMIN  150 // this is the 'minimum' pulse length count (out of 4096)
#define SERVOMAX  600 // this is the 'maximum' pulse length count (out of 4096)

void setup() {
  Serial.begin(9600);
  Serial.println("8 channel Servo test!");

  pwm.begin();
  
  pwm.setPWMFreq(60);  // Analog servos run at ~60 Hz updates

  delay(10);
}

void loop() {
  byte joints [7];
  // check if data has been sent from the computer:
  if (Serial.available() == 7) {
    // read the most recent byte (which will be from 0 to 255):
    for(int i = 0; i < 7; ++i)
      joints[i] = Serial.read();
    DWRITE(0, joints[5]-50);//left arm pitch
    DWRITE(1, joints[2]-40);//left arm roll
    DWRITE(2,joints[6]-90);//left elbow
  
    DWRITE(14, 220-joints[1]);//right arm
    DWRITE(15, joints[3]);//right arm shoulder pitch
    DWRITE(13, 270-joints[4]);//right elbow
  }
}
