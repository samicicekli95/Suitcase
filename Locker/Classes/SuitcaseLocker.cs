using Locker.Enums;
using Locker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locker.Classes
{
    class SuitcaseLocker : IDigitalLock
    {
        // Class Variables
        private bool _isLocked;
        private List<char> _keyOptions;
        private List<char> _cipher;
        private List<char> _currentKeys;


        public SuitcaseLocker()
        {
            // Default Values
            _isLocked = false;
            _keyOptions = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            _cipher = new List<char>(4);
            _currentKeys = new List<char>(4);
        }


        public bool Turn(TurnDirection direction, int circleIndex, int step)
        {
            char _currentKey = Read(circleIndex);
            if(_currentKey == '?')
            {
                _currentKey = _keyOptions.First();
                _currentKeys.Add(_currentKey);
                circleIndex = _currentKeys.LastIndexOf(_currentKey);
            }
            int _currentKeyIndex = _keyOptions.FindIndex(p => p.Equals(_currentKey));

            // New Index
            if(direction == TurnDirection.Forward)
            {
                _currentKeyIndex = _currentKeyIndex + step;
            }
            else
            {
                _currentKeyIndex = _currentKeyIndex - step;
            }

            while (_currentKeyIndex < 0)
            {
                _currentKeyIndex = _currentKeyIndex + _keyOptions.Count;
            }

            _currentKeyIndex = _currentKeyIndex % _keyOptions.Count;
            _currentKeys[circleIndex] = _keyOptions[_currentKeyIndex];



            return true;
        }

        // Complated Methods

        public int GetCipherLength()
        {
            if (_isLocked)
            {
                return _cipher.Count;
            }
            else
            {
                return _currentKeys.Count;
            }
        }

        public bool IsLocked()
        {
            return _isLocked;
        }

        public char Read(int circleIndex)
        {
            char value = '?';
            if (circleIndex >= 0 && circleIndex < _currentKeys.Count)
            {
                value = _currentKeys[circleIndex];
            }

            return value;
        }

        public string ReadAll()
        {
            string value = "";

            if (_currentKeys.Count > 0)
            {
                for (int i = 0; i < _currentKeys.Count; i++)
                {
                    value = value + _currentKeys[i];
                }
            }

            return value;
        }

        public bool Reset()
        {
            if (_currentKeys.Count > 0)
            {
                for (int i = 0; i < _currentKeys.Count; i++)
                {
                    _currentKeys[i] = _keyOptions[0];
                }

                return true;
            }

            return false;
        }

        public bool Lock(bool garbleAfterLock)
        {
            if (!_isLocked)
            {
                _cipher.Clear();
                for (int i = 0; i < _currentKeys.Count; i++)
                {
                    _cipher.Add(_currentKeys[i]);
                }
                _isLocked = true;
                if (garbleAfterLock)
                {
                    Random r = new Random();
                    int n;
                    for (int i = 0; i < _currentKeys.Count; i++)
                    {
                        n = r.Next(0, _keyOptions.Count - 1);
                        _currentKeys[i] = _keyOptions[n];
                    }
                }

                return true;
            }

            // Already locked. To lock the cipher, it must be unlocked.
            return false;
        }

    }

    /*
     
    class SuitcaseLocker : IDigitalLock
    {
        // Variables
        private bool _isLocked;                 // Is locked?
        private int _cipherLength;              // 
        private List<char> _keyOptions;         // Different Key Values
        private List<int> _selectedKeys;        // Passcode
        private List<int> _keyValues;

        // Constructor, default values of instance
        public SuitcaseLocker()
        {
            _isLocked = false;
            _cipherLength = 4;                  // Minimum Length of Passcode
            _keyOptions = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            _selectedKeys = new List<int>();
            _keyValues = new List<int>();
            for (int i = 0; i < _cipherLength; i++)
            {
                _selectedKeys.Add(0);
                _keyValues.Add(0);
            }
        }

        public int GetCipherLength()
        {
            return _selectedKeys.Count;
        }
        public bool IsLocked()
        {
            return _isLocked;
        }

        // TODO: Read Method
        public char Read(int circleIndex)
        {
            return _keyOptions[_keyValues[circleIndex]];
        }

        public string ReadAll()
        {
            string returnValue = "";
            for (int i = 0; i < _keyValues.Count; i++)
            {
                // returnValue = returnValue + _keyOptions[_keyValues[i]];
                returnValue = returnValue + Read(i);
            }
            return returnValue;
        }

        public bool Reset()
        {
            for (int i = 0; i < _keyValues.Count; i++)
            {
                _keyValues[i] = 0;
            }
            return true;
        }


        // TODO: Turn Method
        public bool Turn(TurnDirection direction, int circleIndex, int step)
        {
            step = step % _keyOptions.Count;
            if (circleIndex >= _keyValues.Count || circleIndex < 0)
            {
                _keyValues.Add(_keyOptions[0]);
                circleIndex = _keyValues.Count - 1;
            }

            if(direction == TurnDirection.Forward)
            {
                _keyValues[circleIndex] = Read(circleIndex + step);
            }
            else
            {
                _keyValues[circleIndex] = Read(circleIndex - step);
            }

            return true;
        }

        // TODO: Lock Method
        public bool Lock(bool garbleAfterLock)
        {
            // Lock it only if it's not locked
            if (!_isLocked)
            {
                _selectedKeys.Clear();
                for(int i = 0; i < _keyValues.Count; i++)
                {
                    _selectedKeys.Add(_keyValues[i]);
                }
                if (garbleAfterLock) // Kilitlendikten sonra karıştır
                {

                }
                _isLocked = true;
                return true;
            }
            
            return false;
        }
    }

     */
}
