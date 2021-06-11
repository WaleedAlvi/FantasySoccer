import React, { useState } from 'react';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/rootStore';
import { Link, useHistory } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const { userStore } = useStore();
  const history = useHistory();

  const handleEmailChange = (event: any) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event: any) => {
    setPassword(event.target.value);
  };

  const handleSubmit = (event: any) => {
    event.preventDefault();

    try {
      userStore.login(email, password).then(() => {
        if (userStore.IsLoggedIn) history.push('/');
      });
    } catch {
      userStore.errorExists = true;
      userStore.errorMessage = 'Failed to Login';
    }
  };

  return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-gray-300">
      <div className="flex flex-col bg-white shadow-md px-4 sm:px-6 md:px-8 lg:px-10 py-8 rounded-md w-full max-w-md">
        <div className="font-normal self-center sm:text-2xl uppercase text-gray-800">
          Login To Your Account
        </div>
        <button className="relative mt-6 border rounded-md py-2 text-lg text-gray-800 bg-gray-100 hover:bg-blue-500 hover:text-gray-50 inline-flex items-center justify-center">
          <svg
            className="absolute left-3 h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path d="M12 0c-6.627 0-12 5.373-12 12s5.373 12 12 12 12-5.373 12-12-5.373-12-12-12zm3 8h-1.35c-.538 0-.65.221-.65.778v1.222h2l-.209 2h-1.791v7h-3v-7h-2v-2h2v-2.308c0-1.769.931-2.692 3.029-2.692h1.971v3z" />
          </svg>
          <span>Login with Facebook</span>
        </button>
        <button className="relative mt-6 border rounded-md py-2 text-lg text-gray-800 bg-gray-100 hover:bg-red-500 hover:text-gray-50 inline-flex items-center justify-center">
          <svg
            className="absolute left-3 h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path d="M12 0c-6.627 0-12 5.373-12 12s5.373 12 12 12 12-5.373 12-12-5.373-12-12-12zm0 2c5.514 0 10 4.486 10 10s-4.486 10-10 10-10-4.486-10-10 4.486-10 10-10zm5.144 14.5h-10.288c-.472 0-.856-.384-.856-.856v-6.788c0-.472.384-.856.856-.856h10.288c.472 0 .856.384.856.856v6.788c0 .472-.384.856-.856.856zm-5.144-3.043l-4.671-3.241-.01 5.784h9.342v-5.784l-4.661 3.241zm4.435-4.957h-8.895l4.46 3.115s3.126-2.203 4.435-3.115z" />
          </svg>
          <span>Login with Google</span>
        </button>
        <div className="relative mt-10 h-px bg-gray-300">
          <div className="absolute left-0 top-0 flex justify-center w-full -mt-2">
            <span className="bg-white px-4 text-xs text-gray-500 uppercase">
              Or Login With Email
            </span>
          </div>
        </div>
        {userStore.errorExists ? (
          <div className="relative mt-6 border rounded-md py-2 text-xl text-white bg-red-300 inline-flex items-center justify-center">
            <span>{userStore.errorMessage}</span>
          </div>
        ) : null}
        <div className="mt-10">
          <form onSubmit={handleSubmit}>
            {/* Email */}
            <div className="flex flex-col mb-6">
              <div className="relative">
                <div className="inline-flex items-center justify-center absolute left-0 top-0 h-full w-10 text-gray-400">
                  <svg
                    className="h-6 w-6"
                    fill="none"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                  >
                    <path d="M16 12a4 4 0 10-8 0 4 4 0 008 0zm0 0v1.5a2.5 2.5 0 005 0V12a9 9 0 10-9 9m4.5-1.206a8.959 8.959 0 01-4.5 1.207" />
                  </svg>
                </div>
                <input
                  id="email"
                  type="email"
                  name="email"
                  className="text-sm sm:text-base placeholder-gray-500 pl-10 pr-4 rounded-lg border border-gray-400 w-full py-2 focus:outline-none focus:border-blue-400"
                  placeholder="E-Mail Address"
                  value={email}
                  onChange={handleEmailChange}
                />
              </div>
            </div>
            {/* Password */}
            <div className="flex flex-col mb-6">
              <div className="relative">
                <div className="inline-flex items-center justify-center absolute left-0 top-0 h-full w-10 text-gray-400">
                  <svg
                    className="h-6 w-6"
                    fill="none"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                  >
                    <path d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                  </svg>
                </div>
                <input
                  id="password"
                  type="password"
                  name="password"
                  className="text-sm sm:text-base placeholder-gray-500 pl-10 pr-4 rounded-lg border border-gray-400 w-full py-2 focus:outline-none focus:border-blue-400"
                  placeholder="Password"
                  value={password}
                  onChange={handlePasswordChange}
                />
              </div>
            </div>
            <div className="flex items-center mb-6 -mt-4">
              <div className="flex ml-auto">
                <a
                  href="#"
                  className="inline-flex text-xs sm:text-sm text-blue-500 hover:text-blue-700"
                >
                  <Link to="/forgotpassword">Forgot Your Password?</Link>
                </a>
              </div>
            </div>
            {/* Submit */}
            <div className="flex w-full">
              <button
                type="submit"
                className="flex items-center justify-center focus:outline-none text-white text-sm sm:text-base bg-blue-600 hover:bg-blue-700 rounded py-2 w-full transition duration-150 ease-in"
              >
                <span className="mr-2 uppercase">Login</span>
              </button>
            </div>
          </form>
        </div>
        <div className="relative mt-10">
          <div className="absolute left-0 top-0 flex justify-center w-full -mt-2">
            <a href="#">
              <span className="bg-white px-4 text-xs text-gray-500 uppercase hover:text-blue-700">
                <Link to="/signup">No Account? Sign Up</Link>
              </span>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default observer(Login);
