import React, { useRef, useState } from 'react';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/rootStore';
import { Link, useHistory } from 'react-router-dom';
import Modal from '../../app/shared/hooks/modal';

const ForgotPassword = () => {
  const modal: any = useRef(null);
  const [email, setEmail] = useState<string>('');
  const { userStore } = useStore();
  const history = useHistory();

  const handleEmailChange = (event: any) => {
    setEmail(event.target.value);
  };

  const handleSubmit = (event: any) => {
    event.preventDefault();

    try {
      userStore.resertPassword(email).then(() => {
        modal.current.open();
        //history.push('/login');
      });
    } catch {}
  };

  return (
    <div>
      <div className="min-h-screen flex flex-col items-center justify-center bg-gray-300">
        <div className="flex flex-col bg-white shadow-md px-4 sm:px-6 md:px-8 lg:px-10 py-8 rounded-md w-full max-w-md">
          <div className="font-normal self-center sm:text-2xl uppercase text-gray-800">
            Forgot Password? Enter your email address to reset it
          </div>
          <div className="mt-10">
            <form onSubmit={handleSubmit}>
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
                    onChange={handleEmailChange}
                  />
                </div>
              </div>
              <div className="flex w-full">
                <button
                  type="submit"
                  className="flex items-center justify-center focus:outline-none text-white text-sm sm:text-base bg-blue-600 hover:bg-blue-700 rounded py-2 w-full transition duration-150 ease-in"
                >
                  <span className="mr-2 uppercase">Submit</span>
                </button>
              </div>
            </form>
          </div>
          <div className="relative mt-10">
            <div className="absolute left-0 top-0 flex justify-center w-full -mt-2">
              <a href="#">
                <span className="bg-white px-4 text-xs text-gray-500 uppercase hover:text-blue-700">
                  <Link to="/login">Login</Link>
                </span>
              </a>
            </div>
          </div>
        </div>
      </div>
      <Modal
        defaultOpen={false}
        ref={modal}
        ModalTitle={'Password Reset In Progress'}
      >
        <h3>Check your email for instructions to reset yourpassword</h3>
      </Modal>
    </div>
  );
};

export default observer(ForgotPassword);
