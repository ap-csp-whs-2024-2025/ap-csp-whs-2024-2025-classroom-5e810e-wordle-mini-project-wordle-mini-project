/**
* listhelpers.hpp has been provided by the instructor as starter code
* contains the following procedures to work with lists:
* display, append, insert, remove, length
*/
#include "listhelpers.hpp"

#include <cstdlib>   // srand, rand
#include <ctime>     // time
#include <iostream>  // std::cin, std::cout
#include <string>    // std::string, std::getline
#include <vector>    // std::vector

// Function to generate a secret code of 4 random numbers from 1-9
std::vector<int> createSecret() {
    std::vector<int> secret;
    srand(time(0)); // Seed random number generator
    for (int i = 0; i < 4; i++) {
        secret.push_back(rand() % 9 + 1); // Random number between 1 and 9
    }
    return secret;
}

// Function to generate hints based on user guess
std::vector<std::string> getHint(std::vector<int> secret, std::vector<int> guess) {
    std::vector<std::string> hint(4, "X");
    
    for (int i = 0; i < 4; i++) {
        if (secret[i] == guess[i]) {
            hint[i] = "O"; // Correct number and position
        }
    }
    
    return hint;
}

// Function to check if the user has won the game
bool winGame(std::vector<int> secret, std::vector<int> guess) {
    return secret == guess;
}

int main() {
    std::vector<int> secret_code = createSecret();
    std::vector<int> user_guess(4);
    std::vector<std::string> hint;
    int num_guesses = 0;
    
    std::cout << "Welcome to Number Wordle! Guess the 4-digit secret code using numbers 1-9.\n";
    
    do {
        std::cout << "\nEnter your guess: ";
        
        // Reset user_guess before taking input
        for (int i = 0; i < 4; i++) {
            std::cin >> user_guess[i];
        }

        // Generate and display hint
        hint = getHint(secret_code, user_guess);
        display(hint);
        num_guesses++;
        
    } while (!winGame(secret_code, user_guess)); // Repeat until the user wins
    
    std::cout << "Congrats! You guessed the code in " << num_guesses << " tries.\n";
    return 0;
}