using UnityEngine;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PW
{
    public class GameManager : MonoBehaviour
    {
        public GameObject finishPanel; // Use GameObject instead of Canvas or Panel directly
        public Image starIcon;
        private int rightOrders = 0;
        private int ordersOutOfTime = 0;
        private bool gameFinished = false;


        private void OnEnable()
        {
            BasicGameEvents.onOrderCompleted += OnOrderCompleted;
            BasicGameEvents.onOrderCancelled += OnOrderCancelled;
        }

        private void OnDisable()
        {
            BasicGameEvents.onOrderCompleted -= OnOrderCompleted;
            BasicGameEvents.onOrderCancelled -= OnOrderCancelled;
        }

        private void OnOrderCompleted(int ID, float percentageSuccess)
        {
            if (!gameFinished)
            {
                rightOrders++;
                CheckGameCompletion();
            }
        }

        private void OnOrderCancelled(int ID)
        {
            if (!gameFinished)
            {
                ordersOutOfTime++;
                CheckGameCompletion();
            }
        }

        private void CheckGameCompletion()
        {
            if (rightOrders >= 5)
            {
                gameFinished = true;
                FinishGame();
            }
        }

        private void FinishGame()
        {
            int stars = CalculateStars();
            int coinsToAdd = stars * 100;
            int nrcoins = PlayerPrefs.GetInt("EarnedCoins");
            //nrcoins++;
            nrcoins+= coinsToAdd;
            PlayerPrefs.SetInt("EarnedCoins", nrcoins);
            PlayerPrefs.Save();
            DisplayStars(stars);
            //DisplayStars(stars);
            finishPanel.SetActive(true); // Use SetActive on the GameObject
        }

        public int CalculateStars()
        {
            if (ordersOutOfTime == 0)
            {
                return 3;
            }
            else if (ordersOutOfTime <= 3)
            {
                return 2;
            }
            else if (ordersOutOfTime <= 6)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void DisplayStars(int stars)
        {
            print(stars);

            // Clear existing stars
            foreach (Transform child in finishPanel.transform)
            {
                Destroy(child.gameObject);
            }

            // Duplicate the existing star image based on the number of stars
            for (int i = 0; i < 3; i++)
            {
                GameObject star = Instantiate(starIcon.gameObject);
                star.transform.SetParent(finishPanel.transform);
                star.SetActive(true);

                // Calculate the alpha (transparency) based on the current star's position
                float alpha = i < stars ? 1f : 0.3f; // Adjust the alpha values as needed

                // Set the alpha of the star image
                Image starImage = star.GetComponent<Image>();
                Color starColor = starImage.color;
                starColor.a = alpha;
                starImage.color = starColor;

                // Set the position of the star
                RectTransform starRectTransform = star.GetComponent<RectTransform>();

                float xPos; // Adjust the X position based on your requirements
                float yPos; // Adjust the Y position based on your requirements
                if (i == 0)
                {
                    xPos = -250f;
                    yPos = 100f;
                }
                else
                {
                    if (i == 1)
                    {
                        xPos = 0f;
                        yPos = 150f;
                    }
                    else
                    {
                        xPos = 250f;
                        yPos = 100f;
                    }
                }

                starRectTransform.anchoredPosition = new Vector2(xPos, yPos);

                float starSize;
                // Adjust the size of the star
                if (i == 1)
                {
                    starSize = 85f;
                }
                else
                {
                    starSize = 70f;
                }
                // Adjust the size based on your requirements
                starRectTransform.sizeDelta = new Vector2(starSize, starSize);
            }
        }
    }
}