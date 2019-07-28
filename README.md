# RL-car Simulator

Deep Reinforcement Learning (PPO) car simulator using unity engine and python.


## Software

* Windows10 (64bit)
* Python 3.6
* Anaconda3 5.0.1
* Tensorflow 1.7.1

## Hardware

CPU: Intel(R) Core(TM) i5-4200U CPU @ 1.60GHz 2.30GHz

## Languages
* python
* C#

## Integrating the game (C#) with the alg (python)

using unity SDK ml-agents

## RL algorithm used

PPO (Proximal Policy Optimization)

## Description of folders

* RL-3D-simulator is unity project for 3D car simulator,ready to be trained.
* RL-Unity is unity project for 2D car simulator, ready to be trained.
* UnityGame is unity project for the 2D game only without ml-agents setup and scripts.

## How to Run this Project
 
 1. Download unitySDK repo https://github.com/Unity-Technologies/ml-agents
 2. Install the ml-agents as shown here https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Installation.md
 3. download this repo,then open the RL-3D-simulator unity project in unity and goto Assets->ml-agents->myCar->scene then click SampleScene.
 4. To train the game https://github.com/Unity-Technologies/ml-agents/blob/master/docs/Training-ML-Agents.md
 
 ## Simulator:
 
 ### 3D Model gif
 
 ![3d_car_for_gif](https://user-images.githubusercontent.com/33907411/62006491-6232d580-b141-11e9-887d-82ef414bc7e6.gif)


## Vector Observation states

Opponent cars position
agent car position

## Actions

The action of the vehicle is as follows.

* Do nothing
* move left
* move right
* move backward
* move forward

## Reward design 
* -1 when agent collide the opponent cars
* -1 when agent collide with road boundaries
* 0.5 when agent moves forward
* 0.2 when agent moves right or left 

## Results 

after 2 Hours training with PPO algorithm

#### Reward

![Phase2_reward](https://user-images.githubusercontent.com/33907411/62006624-62cc6b80-b143-11e9-8e67-68c2eecc7a2f.JPG)


#### Losses

![Phase2_losses](https://user-images.githubusercontent.com/33907411/62006638-94453700-b143-11e9-872e-58c6c91e916c.JPG)


 


