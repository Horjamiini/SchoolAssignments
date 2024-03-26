#include <iostream>
#include <thread>
#include <vector>
#include <condition_variable>
#include <mutex>
#include <functional>

using namespace std;

class App 
{
public:
    App() :
        m_DataLoaded1(false),
        m_DataLoaded2(false),
        m_DataLoaded3(false),
        m_DataLoaded4(false),
        m_DataLoaded5(false)
    {
    }
    

    bool DataComlete1() const { return m_DataLoaded1; }
    bool DataComlete2() const { return m_DataLoaded2; }
    bool DataComlete3() const { return m_DataLoaded3; }
    bool DataComlete4() const { return m_DataLoaded4; }
    bool DataComlete5() const { return m_DataLoaded5; }

    void Process()
    {
        lock_guard<mutex> guard(m_m1);

        for (int i = 0; i < 20; ++i)
        {
            m_m1.unlock();
            this_thread::sleep_for(chrono::milliseconds(200));
            m_m1.lock();
        }

        m_DataLoaded1 = true;

        m_condVar1.notify_one();


        for (int i = 0; i < 20; ++i)
        {
            m_m1.unlock();
            this_thread::sleep_for(chrono::milliseconds(200));
            m_m1.lock();
        }

        m_DataLoaded2 = true;

        m_condVar2.notify_one();


        for (int i = 0; i < 20; ++i)
        {
            m_m1.unlock();
            this_thread::sleep_for(chrono::milliseconds(200));
            m_m1.lock();
        }

        m_DataLoaded3 = true;

        m_condVar3.notify_one();


        for (int i = 0; i < 20; ++i)
        {
            m_m1.unlock();
            this_thread::sleep_for(chrono::milliseconds(200));
            m_m1.lock();
        }

        m_DataLoaded4 = true;

        m_condVar4.notify_one();


        for (int i = 0; i < 20; ++i)
        {
            m_m1.unlock();
            this_thread::sleep_for(chrono::milliseconds(200));
            m_m1.lock();
        }

        m_DataLoaded5 = true;

        m_condVar5.notify_one();
    }

    void Information()
    {
        unique_lock<mutex> locket(m_m1);

        cout << "Starting process\n";
        
        m_condVar1.wait(locket, bind(&App::DataComlete1, this));

        cout << "Process is 20% done\n";

        m_condVar2.wait(locket, bind(&App::DataComlete2, this));

        cout << "Process is 40% done\n";

        m_condVar3.wait(locket, bind(&App::DataComlete3, this));

        cout << "Process is 60% done\n";
        m_condVar4.wait(locket, bind(&App::DataComlete4, this));

        cout << "Process is 80% done\n";

        m_condVar5.wait(locket, bind(&App::DataComlete5, this));

        cout << "Process is 100% done\n";

        cout << "Process completed!";
    }

private:
    mutex               m_m1;
    condition_variable  m_condVar1;
    condition_variable  m_condVar2;
    condition_variable  m_condVar3;
    condition_variable  m_condVar4;
    condition_variable  m_condVar5;
    bool                m_DataLoaded1;
    bool                m_DataLoaded2;
    bool                m_DataLoaded3;
    bool                m_DataLoaded4;
    bool                m_DataLoaded5;
};

int main()
{
    App app;
    thread t1(&App::Process, &app);
    thread t2(&App::Information, &app);

    if (t1.joinable())
    {
        t1.join();
    }
    if (t2.joinable())
    {
        t2.join();
    }
}
