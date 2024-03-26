#include <iostream>
#include <vector>
#include <thread>
#include <cstdlib>
#include <time.h>
#include <future>
#include <Windows.h>

using namespace std;

class Sensor
{
public:

    thread t1;

    Sensor()
    {

    }

    static void sensorData(vector <int>& data)
    {
        srand(time(NULL));
        for (int i = 0; i < 2000; ++i)
        {
            data.push_back(rand() % 4096);
        }
    }

    static void readData(vector <int>& data)
    {
        thread t1(sensorData, (ref(data)));
        t1.join();
    }
};

class SensorReader : Sensor
{
public:
    promise <int> lupaus;
    vector <int> data;
    Sensor sensor1;
    Sensor sensor2;
    Sensor sensor3;
    Sensor sensor4;

    SensorReader()
    {

    }

    void readValues()
    {
        thread t2(Sensor::readData, (ref(data)));
        t2.join();


        for (auto value : data)
        {
            if (value > 4000)
            {
                lupaus.set_value(value);
                cout << "Read: " << lupaus.get_future().get() << "\n";
                lupaus = promise<int>();
            }
        }
    }
};
int main(promise <int>& lupaus)
{
    SensorReader sensorReader;

    cout << "Starting process... \n";

    while (true)
    {
        sensorReader.readValues();

        {
            if (GetAsyncKeyState(VK_SPACE) == 1)
            {
                cout << "Exiting program" << endl;
                return 0;
            }
        }
    }
}
